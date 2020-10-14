using UnityEngine;

public class Flag : MonoBehaviour {
    //public GameObject VictoryScreen;
    private GameMaster gameMaster;
    void Awake () {
        gameMaster = Camera.main.GetComponent<GameMaster> ();
    }
    void PlayerCompletedLevel () {
        gameMaster.CompletedLevel ();
    }
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer ("Player")) {
            PlayerCompletedLevel ();
        }
    }
}