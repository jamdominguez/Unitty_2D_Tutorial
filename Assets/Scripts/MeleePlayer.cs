using UnityEngine;

public class MeleePlayer : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private float horizontal;
    private bool running;
    public bool grounded;
    public float distanceToGround;

    private Animator animatorComp;
    private Rigidbody2D rigidbody2DComp;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.5f;
        jumpForce = 700f;
        animatorComp = GetComponent<Animator>();
        rigidbody2DComp = GetComponent<Rigidbody2D>();
        rigidbody2DComp.mass = 1.4f;
        rigidbody2DComp.gravityScale = 3.3f;
        grounded = true;
        distanceToGround = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        // Get Horizontal movement
        horizontal = Input.GetAxisRaw("Horizontal");

        // Set if is running
        running = horizontal != 0.0f;
        animatorComp.SetBool("running", running);

        // Turn sprite according movement orientation
        if (horizontal < 0.0f) transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1, 1, 1);

        // Jump
        grounded = Physics2D.Raycast(transform.position, Vector3.down, distanceToGround) ? true : false;
        if (Input.GetKeyDown(KeyCode.Space) && grounded) Jump();
    }

    private void FixedUpdate()
    {
        rigidbody2DComp.velocity = new Vector2(horizontal * speed, rigidbody2DComp.velocity.y);
    }

    private void Jump() {        
        rigidbody2DComp.AddForce(Vector2.up * jumpForce);
    }

}
