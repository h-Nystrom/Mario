using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public TMP_Text lifesTxt, scoreTxt, timeLeftTxt, levelTxt, deathMessageTxt;
    public GameObject victoryUI, gameOverUI; //PauseUI;//GameOverUI
    public PlayerController playerController;
    string deathMessage;
    public float maxTime;
    float currentTimeLeft, savedMaxTime;
    public int nextLevel;
    bool turnOffTimeLeft;
    void Start () {
        savedMaxTime = maxTime;
        lifesTxt.text = $"Lifes: {StaticGameSessionData.Lifes}";
        scoreTxt.text = StaticGameSessionData.Score.ToString ();
        levelTxt.text = $"{StaticGameSessionData.CurrentLevel} : 1";
        StaticGameSessionData.CurrentLevel = nextLevel;
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
            timeLeftTxt.text = currentTimeLeft.ToString ("00.0s");
        } else {
            RemoveOneHealth ("Time ran out!");
        }

    }
    public void RemoveOneHealth (string deathMessage) { //String to know what killed the player.
        this.deathMessage = deathMessage;
        playerController.deActivateController = true;
        turnOffTimeLeft = true;
        if (!StaticGameSessionData.PlayerIsDead) {
            StaticGameSessionData.Lifes -= 1;
            lifesTxt.text = $"Lifes: {StaticGameSessionData.Lifes}";
            GameOver ();
        }
    }
    void ResetCurrentTimeleft () {
        maxTime = savedMaxTime + Time.time;
    }
    public void CompletedLevel () {
        playerController.deActivateController = true;
        turnOffTimeLeft = true;
        victoryUI.SetActive (true);
    }
    public void GameOver () { //Takes string to show message//Save score to a playerprefs here!
        gameOverUI.SetActive (true);
        deathMessageTxt.text = "You died of:" + deathMessage;
    }
    public void ResetGame () {
        StaticGameSessionData.Lifes = 3;
        StaticGameSessionData.Score = 0;
        StaticGameSessionData.CurrentLevel = 0;
        NextLevel ();
    }
    public void RestartLevel () {
        if (!StaticGameSessionData.PlayerIsDead) {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        } else
            ResetGame ();

    }
    public void NextLevel () {
        SceneManager.LoadScene (StaticGameSessionData.CurrentLevel, LoadSceneMode.Single); //Change number to the right one!
    }
    public void QuitGame () {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif

    }
}