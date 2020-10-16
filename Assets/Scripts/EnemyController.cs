using UnityEngine;

public class EnemyController : MonoBehaviour {
    public int state;
    public float speed;
    public float minJumpPower, maxJumpPower;
    public bool onGround;
    public float stateTimer, jumpDelay;
    public float trackingDistance = 5;
    Rigidbody2D rb;
    Transform target;
    bool changeDir;

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    void FixedUpdate () {
        PickCurrentState ();
        FollowTarget ();
        Walk ();
    }
    enum CurrentState {
        TurnLeft,
        TurnRight,
        Wait,
        DefaultState
    }
    void PickCurrentState () {
        switch (state) {
            case (int) CurrentState.TurnLeft:
                speed = -8;
                state = (int) CurrentState.DefaultState;
                break;
            case (int) CurrentState.TurnRight:
                speed = 8;
                state = (int) CurrentState.DefaultState;
                break;
            case (int) CurrentState.Wait:
                speed = 0;
                break;
            case (int) CurrentState.DefaultState:
                break;
        }

    }
    void StateTimer () {
        if (onGround)
            stateTimer += 1 * Time.deltaTime;
        if (stateTimer > Random.Range (6, 10)) {
            state = Random.Range (0, 3);
            stateTimer = 0;
        }
    }
    void Jump () {
        if (onGround) {
            jumpDelay += 1 * Time.deltaTime;
            if (jumpDelay > 0.1f) {
                rb.AddForce (Vector2.up * Random.Range (minJumpPower, maxJumpPower), ForceMode2D.Impulse);
                jumpDelay = 0;
            }
        } else
            jumpDelay = 0;
    }
    void Walk () {
        rb.AddForce (Vector2.right * speed);
        Jump ();
    }
    void FollowTarget () {
        if (Vector2.Distance (transform.position, target.position) < trackingDistance) {
            WalkDirection (target.position, (int) CurrentState.TurnLeft, (int) CurrentState.TurnRight);
        } else {
            StateTimer ();
        }
    }
    void WalkDirection (Vector3 col, int dir1, int dir2) {
        Vector3 colPoint = col;
        Vector3 dir = (transform.position - colPoint).normalized;

        if (dir.x > 0.1f) {
            state = dir1;
        } else if (dir.x < -0.1f) {
            state = dir2;
        }
    }
    void OnCollisionStay2D (Collision2D col) {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy") {
            WalkDirection (col.contacts[0].point, (int) CurrentState.TurnRight, (int) CurrentState.TurnLeft);

        }
        if (col.gameObject.tag == "Ground") {
            onGround = true;
        }
    }
    void OnTriggerStay2D (Collider2D col) {
        if (col.gameObject.tag == "EnemyBoundary") {
            WalkDirection (col.transform.position, (int) CurrentState.TurnRight, (int) CurrentState.TurnLeft);
        }
    }
    void OnCollisionExit2D (Collision2D col) {
        if (col.gameObject.tag == "Ground") {
            onGround = false;
        }
    }
}