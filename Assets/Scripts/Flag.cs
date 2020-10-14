using TMPro;
using UnityEngine;

public class Flag : MonoBehaviour {
    public GameObject VictoryScreen;
    public TMP_Text timeText;
    float time;
    void LateUpdate () {
        time = Time.time;
    }
    void PlayerCompletedLevel () {
        if (VictoryScreen != null && timeText != null) {
            //Add animation and sound here!
            VictoryScreen.SetActive (true);
            Time.timeScale = 0;
            timeText.text = time.ToString ("Time: 0.0s");
        }
    }
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer ("Player")) {
            PlayerCompletedLevel ();
        }
    }
}