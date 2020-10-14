using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    PlayerInputSystem controls;
    Rigidbody2D rb;
    Vector2 movement;
    bool jump;
    public float speed;
    public float jumpPower;
    public float jumpTime;
    public float jumpMaxTime;
    public float maxGravity;
    public bool onGround;

    void Awake () {
        controls = new PlayerInputSystem ();

        controls.Input.Movement.performed += ctx => movement = ctx.ReadValue<Vector2> ();
        controls.Input.Movement.canceled += ctx => movement = Vector2.zero;

        controls.Input.Jump.performed += ctx => jump = true;
        controls.Input.Jump.canceled += ctx => jump = false;
    }
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        Movement (movement);
        Jump ();
    }
    void Movement (Vector2 movement) {
        rb.AddForce (transform.right * speed * movement.x);
    }
    void Jump () {
        if (onGround == true) {
            jumpTime = Time.time + jumpMaxTime;
        }

        if (Time.time < jumpTime && jump)
            rb.AddForce (transform.up * jumpPower);
        else if (!onGround) {
            if (rb.gravityScale < maxGravity) { }
            rb.gravityScale += 1.4f * Time.deltaTime;
        } else
            rb.gravityScale = 1;
    }
    void OnCollisionStay2D (Collision2D col) {
        if (col.transform.tag == "Ground") {
            onGround = true;
        }
    }
    void OnCollisionExit2D (Collision2D col) {
        if (col.transform.tag == "Ground") {
            onGround = false;
        }
    }
    void OnEnable () {
        controls.Enable ();
    }
    void OnDisable () {
        controls.Disable ();
    }
}