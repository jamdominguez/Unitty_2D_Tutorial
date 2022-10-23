using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntMovement : MonoBehaviour
{
    public float speed;
    public GameObject John;
    public GameObject BulletPrefab;    




    private Animator Animator;
    private Rigidbody2D Rigidbody2D;

    private const float MAX_MOVEMENT_X = 1f;
    private const float DISTANCE_TO_SHOT = 1f;
    private const float SHOOT_DELAY = 3f;
    private Vector3 initialPosition;
    private bool runningRight;
    private float lastShoot;


    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Animator.SetBool("running", false);
        Animator.SetBool("hited", false);
        Rigidbody2D = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        speed = 0.4f;
        runningRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Alwways watching John position
        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1, 1, 1);
        else transform.localScale = new Vector3(-1, 1, 1);

        // Shoot to John
        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);
        if (distance < DISTANCE_TO_SHOT) Shoot();
            
        
    }

    private void FixedUpdate()
    {
        //Patrol();

    }

    private void Shoot() {
        if (Time.time >= lastShoot + SHOOT_DELAY)
        {
            Vector3 direction = transform.localScale.x == 1.0f ? Vector3.right : Vector3.left;
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);            
            bullet.GetComponent<Bullet>().SetDirection(direction, 1f);
            lastShoot = Time.time;
        }
    }

    public void Die() {        
        Animator.SetBool("die", true);
    }

    public void DestroyGrunt()
    {
        Destroy(gameObject);
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
