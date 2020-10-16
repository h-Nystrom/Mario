using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    Rigidbody2D rb;
    public float min, max;
    public bool movingOnYAxis;
    float speed = 5;
    bool active;
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }
    void FixedUpdate () {
        if (!active)
            return;
        if (movingOnYAxis)
            MovePlatform (transform.position.y, transform.up);
        else
            MovePlatform (transform.position.x, transform.right);
    }
    void MovePlatform (float position, Vector3 direction) {
        if (position < min) {
            speed = 5;
        }
        if (position > max) {
            speed = -5;
        }
        rb.MovePosition (transform.position + direction * Time.deltaTime * speed);
    }
    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Player") {
            active = true;
            col.collider.transform.SetParent (transform);
        }
    }
    void OnCollisionExit2D (Collision2D col) {
        if (col.gameObject.tag == "Player") {
            active = true;
            col.collider.transform.SetParent (null);
        }
    }
}