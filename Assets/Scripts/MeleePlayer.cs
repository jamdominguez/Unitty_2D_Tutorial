using UnityEngine;

public class MeleePlayer : MonoBehaviour
{

    public float speed;

    private float horizontal;
    private bool running;

    private Animator animatorComp;
    private Rigidbody2D rigidbody2DComp;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.5f;
        animatorComp = GetComponent<Animator>();
        rigidbody2DComp = GetComponent<Rigidbody2D>();

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
    }

    private void FixedUpdate()
    {
        rigidbody2DComp.velocity = new Vector2(horizontal * speed, rigidbody2DComp.velocity.y);
    }
}
