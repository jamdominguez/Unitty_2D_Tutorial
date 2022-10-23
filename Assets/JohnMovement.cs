using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public GameObject BulletPrefab;
    public float ShootDelayTime;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private float LastShootTime;
    private bool isDie;
    private bool Grounded;
    private bool Running;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        JumpForce = 120;
        Speed = 1.1f;
        Grounded = false;
        ShootDelayTime = 0.25f;
        isDie = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDie) {
            // Get Horizontal movement
            Horizontal = Input.GetAxisRaw("Horizontal");

            // Set if is running
            Running = Horizontal != 0.0f;
            Animator.SetBool("running", Running);

            // Turn sprite according movement orientation
            if (Horizontal < 0.0f) transform.localScale = new Vector3(-1, 1, 1);
            else if (Horizontal > 0.0f) transform.localScale = new Vector3(1, 1, 1);        

            //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
            // Check if is grounded        
            Grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.1f) ? true : false;
            // Jump
            if (Input.GetKeyDown(KeyCode.Space) && Grounded) Jump();

            // Shot
            if (Input.GetKeyDown(KeyCode.K)) Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time >= LastShootTime + ShootDelayTime) {
            Vector3 direction = transform.localScale.x == 1.0f ? Vector3.right : Vector3.left;            
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDirection(direction, 2f);
            LastShootTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        if (!isDie) Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    public void Die() {
        isDie = true;
        Animator.SetBool("die", isDie);        
    }

    

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce); 
    }
}
