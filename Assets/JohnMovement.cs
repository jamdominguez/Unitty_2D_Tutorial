using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public bool Grounded;

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        JumpForce = 120;
        Speed = 1.1f;
        Grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        // Check if is grounded        
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f)) Grounded = true;
        else Grounded = false;
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && Grounded) Jump();
                 
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce); 
    }
}
