using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public TMP_Text lifesTxt, scoreTxt, timeLeftTxt, levelTxt;
    public GameObject victoryUI; //PauseUI;//GameOverUI
    public PlayerController playerController;
    public float maxTime;
    float currentTimeLeft, savedMaxTime;
    public int nextLevel;
    int StartLifes; //Remove health to a new script located on the player named: Player health, this script only displayes the lifes and score;
    void Start () {
        savedMaxTime = maxTime;
        lifesTxt.text = $"Lifes: {StaticGameSessionData.Lifes}";
        scoreTxt.text = StaticGameSessionData.Score.ToString ();
        StaticGameSessionData.CurrentLevel = nextLevel;
        ResetCurrentTimeleft ();
    }
    void LateUpdate () {
        TimeLeft ();
    }
    void TimeLeft () {
        currentTimeLeft = Mathf.Clamp (maxTime - Time.time, 0, savedMaxTime);
        if (currentTimeLeft > 0) {
            timeLeftTxt.text = currentTimeLeft.ToString ($"00.0s");
        } else {
            RemoveOneHealth ();
        }

    }
    public void RemoveOneHealth () {

        if (!StaticGameSessionData.PlayerIsDead) {
            StaticGameSessionData.Lifes -= 1;
            lifesTxt.text = $"Lifes: {StaticGameSessionData.Lifes}";
            if (StaticGameSessionData.PlayerIsDead)
                GameOver ();
            else
                RestartLevel (); //DeathUI
        }
    }
    void ResetCurrentTimeleft () {
        maxTime = savedMaxTime + Time.time;
    }
    public void CompletedLevel () {
        victoryUI.SetActive (true);
    }
    public void GameOver () { //Takes string to show message
        Debug.Log ("Game Over!");
        StaticGameSessionData.Lifes = 3;
        //Save score to a playerprefs here!
        StaticGameSessionData.Score = 0;
        StaticGameSessionData.CurrentLevel = 0;
        NextLevel ();
    }
    public void RestartLevel () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        Time.timeScale = 1;
    }
    public void NextLevel () {
        SceneManager.LoadScene (StaticGameSessionData.CurrentLevel, LoadSceneMode.Single); //Change number to the right one!
        Time.timeScale = 1;
    }
    public void QuitGame () {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif

    }
}