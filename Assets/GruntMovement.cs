using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntMovement : MonoBehaviour
{
    public float speed;

    private Animator Animator;
    private Rigidbody2D Rigidbody2D;
    private Vector3 initialPosition;

    private const float MAX_MOVEMENT_X = 1f;
    private bool runningRight;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Animator.SetBool("running", true);
        Rigidbody2D = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        speed = 0.4f;
        runningRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Patrol();

    }

    private void Patrol() {
        Vector3 currentPosition = transform.position;
        float maxPositionx = initialPosition.x + MAX_MOVEMENT_X;

        // Moving Right
        if (runningRight && currentPosition.x < initialPosition.x + MAX_MOVEMENT_X)
        {
            Rigidbody2D.velocity = new Vector2(speed, Rigidbody2D.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);

        }
        // Moving Left
        if (!runningRight && currentPosition.x > initialPosition.x - MAX_MOVEMENT_X)
        {
            Rigidbody2D.velocity = new Vector2(-speed, Rigidbody2D.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Check Position and update info
        if (runningRight && currentPosition.x >= initialPosition.x + MAX_MOVEMENT_X)
        {
            runningRight = false;
            initialPosition = transform.position;
        }
        else if (!runningRight && currentPosition.x <= initialPosition.x - MAX_MOVEMENT_X)
        {
            runningRight = true;
            initialPosition = transform.position;
        }
    }
}
