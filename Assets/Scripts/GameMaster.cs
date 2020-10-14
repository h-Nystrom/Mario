using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public TMP_Text lifesTxt, coinsTxt, timeLeftTxt, levelTxt;
    public GameObject victoryUI; //PauseUI;//GameOverUI
    public PlayerController playerController;
    public float maxTime;
    float currentTimeLeft, savedMaxTime;
    int startingLifes = 3;
    void Start () {
        savedMaxTime = maxTime;
    }
    void LateUpdate () {
        TimeLeft ();
    }
    void TimeLeft () {
        currentTimeLeft = Mathf.Clamp (maxTime - Time.time, 0, savedMaxTime);
        if (currentTimeLeft > 0) {
            timeLeftTxt.text = currentTimeLeft.ToString ($"00.0s");
        } else if (!IsDead) {
            OnPlayerDeath ();
        }

    }
    public void RemoveOneHealth () {
        startingLifes -= 1;
        lifesTxt.text = $"Lifes: {startingLifes}";
    }
    bool IsDead { get => startingLifes == 0; }
    void ResetCurrentTimeleft () {
        maxTime = savedMaxTime + Time.time;
    }
    public void OnPlayerDeath () {
        if (!IsDead)
            RemoveOneHealth ();
        if (IsDead) {
            Time.timeScale = 0;
        } else {
            ResetCurrentTimeleft ();
            playerController.ResetOnDeath ();
        }
    }
    public void CompletedLevel () {
        victoryUI.SetActive (true);
    }
    public void GameOver () { //Takes string to show message

    }
    public void RestartLevel () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        Time.timeScale = 1;
    }
    public void NextLevel () {
        SceneManager.LoadScene (0, LoadSceneMode.Single); //Change number to the right one!
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