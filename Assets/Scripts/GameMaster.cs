using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

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