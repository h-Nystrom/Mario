using UnityEngine;

public class DoorScript : MonoBehaviour {
    public float doorTimer;
    float startTime;
    public float maxY;
    public float speed;
    Rigidbody2D rb;
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        startTime = Time.time + doorTimer;
    }

    // Update is called once per frame
    void FixedUpdate () {
        OpenDoor ();
    }
    void OpenDoor () {
        if (Time.time > startTime && transform.position.y < maxY) {
            rb.MovePosition (transform.position + transform.up * Time.deltaTime * speed);
        }
    }
}