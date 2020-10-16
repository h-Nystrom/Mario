using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower, doubleJumpPower;
    public float jumpTime;
    float jumpDelayStartTime;
    bool jumpInput;
    float movementInput;
    bool onGround;
    Rigidbody2D rb;
    PlayerInputSystem controls;
    GameMaster gameMaster;

    private bool canDoubleJump, hasDoubleJumped;
    Vector2 startPos;

    public bool deActivateController;
    void Awake () {
        controls = new PlayerInputSystem ();
        gameMaster = Camera.main.GetComponent<GameMaster> ();

        controls.Input.Movement.performed += ctx => movementInput = ctx.ReadValue<float> ();
        controls.Input.Movement.canceled += ctx => movementInput = 0;

        controls.Input.Jump.performed += ctx => jumpInput = true;
        controls.Input.Jump.canceled += ctx => jumpInput = false;

        controls.InputUI.Pause.performed += ctx => gameMaster.Pause ();
    }
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        startPos = transform.position;
        deActivateController = false;
        rb.drag = 1f;
    }
    void FixedUpdate () {
        if (deActivateController)
            SlowDownOnDeath ();
        else {
            Movement (movementInput);
            Jump ();
        }
    }
    public void SlowDownOnDeath () {
        rb.drag = 40f;
    }
    void Movement (float movement) {
        rb.AddForce (Vector2.right * speed * movement);
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
            if (rb.velocity.y > -6f)
                rb.AddForce (transform.up * jumpPower);
            else
                rb.AddForce (transform.up * doubleJumpPower * -rb.velocity.y);
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
    bool DirectionOfCollision (Vector3 col) {
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
        if (col.transform.tag == "Ground") {
            onGround = DirectionOfCollision (col.contacts[0].point);
        }
    }

    void OnCollisionEnter2D (Collision2D col) {

        if (!deActivateController) {
            if (col.gameObject.tag == "Trap") {
                gameMaster.RemoveOneHealth ("Killed by a trap");
            }
            if (col.gameObject.tag == "Enemy") {
                gameMaster.RemoveOneHealth ("Killed by an enemy");
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