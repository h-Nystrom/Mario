using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour {

    [Tooltip ("Lifes, TimeLeft, Level, Death Message")]
    public TMP_Text[] HudUI = new TMP_Text[4];
    [Tooltip ("Pause, Victory, Game over")]
    public GameObject[] screenUI = new GameObject[3];
    [Tooltip ("Pause, Victory, Game over")]
    public GameObject[] firstSelectedMenuButton = new GameObject[3];
    public PlayerController playerController;
    public float maxTime = 80f;
    public int nextLevel;
    string deathMessage;
    float currentTimeLeft, savedMaxTime;
    bool turnOffTimeLeft;
    bool pause;
    enum textUINumber {
        Lifes,
        TimeLeft,
        Level,
        DeathMessage
    }
    enum GameObjectUINumber {
        Pause,
        Victory,
        GameOver
    }
    void Start () {
        savedMaxTime = maxTime;
        HudUI[(int) textUINumber.Lifes].text = $"Lifes: {StaticGameSessionData.Lifes}";
        HudUI[(int) textUINumber.Level].text = $"({StaticGameSessionData.CurrentLevel + 1}/5)";
        turnOffTimeLeft = false;
        ResetCurrentTimeleft ();
    }
    void LateUpdate () {
        TimeLeft ();
    }
    void TimeLeft () {
        if (turnOffTimeLeft)
            return;
        currentTimeLeft = Mathf.Clamp (maxTime - Time.time, 0, savedMaxTime);
        if (currentTimeLeft > 0) {
            HudUI[(int) textUINumber.TimeLeft].text = currentTimeLeft.ToString ("00.0s");
        } else {
            RemoveOneHealth ("You ran out of time!");
        }
    }
    public void RemoveOneHealth (string deathMessage) {
        this.deathMessage = deathMessage;
        playerController.deActivateController = true;
        turnOffTimeLeft = true;
        if (!StaticGameSessionData.PlayerIsDead) {
            StaticGameSessionData.Lifes -= 1;
            HudUI[(int) textUINumber.Lifes].text = $"Lifes: {StaticGameSessionData.Lifes}";
            GameOver ();
        }
    }
    void ResetCurrentTimeleft () {
        maxTime = savedMaxTime + Time.time;
    }
    public void CompletedLevel () {
        playerController.deActivateController = true;
        turnOffTimeLeft = true;
        screenUI[(int) GameObjectUINumber.Victory].SetActive (true);
        NewSelectedButton (firstSelectedMenuButton[(int) GameObjectUINumber.Victory]);
    }
    public void GameOver () {
        screenUI[(int) GameObjectUINumber.GameOver].SetActive (true);
        NewSelectedButton (firstSelectedMenuButton[(int) GameObjectUINumber.GameOver]);
        HudUI[(int) textUINumber.DeathMessage].text = deathMessage;
    }
    public void ResetGame () {
        Time.timeScale = 1;
        StaticGameSessionData.Lifes = 3;
        StaticGameSessionData.CurrentLevel = 0;
        SceneManager.LoadScene (StaticGameSessionData.CurrentLevel, LoadSceneMode.Single);
    }
    public void Pause () {
        pause = !pause;
        if (pause) {
            Time.timeScale = 0;
            screenUI[(int) GameObjectUINumber.Pause].SetActive (true);
            NewSelectedButton (firstSelectedMenuButton[(int) GameObjectUINumber.Pause]);
        } else {
            Time.timeScale = 1;
            screenUI[(int) GameObjectUINumber.Pause].SetActive (false);
        }
    }
    public void RestartLevel () {
        if (!StaticGameSessionData.PlayerIsDead) {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        } else
            ResetGame ();

    }
    public void NextLevel () {
        StaticGameSessionData.CurrentLevel = nextLevel;
        SceneManager.LoadScene (StaticGameSessionData.CurrentLevel, LoadSceneMode.Single);
    }
    public void QuitGame () {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif

    }
    public void NewSelectedButton (GameObject selectedButton) {
        EventSystem.current.SetSelectedGameObject (null);
        EventSystem.current.SetSelectedGameObject (selectedButton);
    }
}