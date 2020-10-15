using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public float jumpTime;
    public bool onGround;
    PlayerInputSystem controls;
    Rigidbody2D rb;
    Vector2 movement;
    bool jump;
    Vector2 startPos;
    GameMaster gameMaster;
    public bool deActivateController;
    void Awake () {
        controls = new PlayerInputSystem ();
        gameMaster = Camera.main.GetComponent<GameMaster> ();
        controls.Input.Movement.performed += ctx => movement = ctx.ReadValue<Vector2> ();
        controls.Input.Movement.canceled += ctx => movement = Vector2.zero;

        controls.Input.Jump.performed += ctx => jump = true;
        controls.Input.Jump.canceled += ctx => jump = false;
    }
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        startPos = transform.position;
        deActivateController = false;
        rb.drag = 0.8f;
    }
    void FixedUpdate () {
        if (deActivateController)
            SlowDownOnDeath ();
        else {
            Movement (movement);
            Jump ();
        }
    }
    public void SlowDownOnDeath () {
        rb.drag = 50f;
    }
    public void ResetOnDeath () {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }
    void Movement (Vector2 movement) {
        rb.AddForce (Vector2.right * speed * movement.x);
    }
    void Jump () {
        if (onGround) {
            jumpTime = Time.time + 0.25f;
        }
        if (Time.time < jumpTime && jump) {
            rb.AddForce (transform.up * jumpPower);
            rb.gravityScale = 1;
        } else if (!onGround) {
            if (rb.gravityScale < 20) {
                rb.gravityScale += 5f * Time.deltaTime;
            }
        } else
            rb.gravityScale = 1.6f;
    }
    void OnCollisionStay2D (Collision2D col) {
        if (col.transform.tag == "Ground") { //Check location from between the player and colission at left of over etc.
            onGround = true;
            //onWall = true;
        }
    }
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Trap" && !deActivateController) {
            gameMaster.RemoveOneHealth ("Trap");
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