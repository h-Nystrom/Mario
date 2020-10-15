using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower, doubleJumpPower;
    public float jumpTime;
    public bool onGround;
    float jumpDelayStartTime;
    PlayerInputSystem controls;
    Rigidbody2D rb;
    Vector2 movement;
    bool jumpInput;
    public bool canDoubleJump, hasDoubleJumped;
    Vector2 startPos;
    GameMaster gameMaster;
    public bool deActivateController;
    void Awake () {
        controls = new PlayerInputSystem ();
        gameMaster = Camera.main.GetComponent<GameMaster> ();
        controls.Input.Movement.performed += ctx => movement = ctx.ReadValue<Vector2> ();
        controls.Input.Movement.canceled += ctx => movement = Vector2.zero;

        controls.Input.Jump.performed += ctx => jumpInput = true;
        controls.Input.Jump.canceled += ctx => jumpInput = false;
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
        bool canJump = JumpDeley ();
        if (onGround) {
            canDoubleJump = false;
            hasDoubleJumped = false;
            if (jumpInput) {
                jumpDelayStartTime = Time.time;
            }
            if (canJump) {
                jumpTime = Time.time + 0.25f;
            }
        }
        if (canDoubleJump && !hasDoubleJumped && jumpInput) {
            DoubleJump ();
        }
        AddJumpForces (jumpTime);
    }
    void DoubleJump () {
        jumpTime = Time.time + 0.25f;
        hasDoubleJumped = true;
        canDoubleJump = false;
    }
    bool JumpDeley () {
        if (Time.time - jumpDelayStartTime < 0.25f)
            return false;
        else
            return true;
    }

    void AddJumpForces (float time) {
        if (Time.time < time && jumpInput) {
            rb.gravityScale = 1f;
            if (rb.velocity.y > -2f)
                rb.AddForce (transform.up * jumpPower, ForceMode2D.Impulse);
            else
                rb.AddForce (transform.up * doubleJumpPower * -rb.velocity.y, ForceMode2D.Impulse);
        } else if (!onGround) {
            if (!jumpInput && !hasDoubleJumped) {
                canDoubleJump = true;
            }

            if (rb.gravityScale < 10) {
                rb.gravityScale += 5f * Time.deltaTime;
            }
        } else {
            rb.gravityScale = 1.6f;
        }
    }
    bool CollisionDirection (Vector3 col) {
        Vector3 colPoint = col;
        Vector3 dir = (transform.position - colPoint).normalized;
        if (dir.y > 0.5f)
            return true;
        else if (dir.x > 0.1f) {
            return true;
        } else if (dir.x < -0.1f) {
            return true;
        } else
            return false;
    }
    void OnCollisionStay2D (Collision2D col) {
        if (col.transform.tag == "Ground") { //Check location from between the player and colission at left of over etc.
            onGround = CollisionDirection (col.contacts[0].point);
        }
    }

    void OnCollisionEnter2D (Collision2D col) {

        if (!deActivateController) {
            if (col.gameObject.tag == "Trap") {
                gameMaster.RemoveOneHealth ("Trap");
            }
            if (col.gameObject.tag == "Enemy") {
                gameMaster.RemoveOneHealth ("Enemy");
            }
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