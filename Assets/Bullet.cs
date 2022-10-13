using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public float speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {        
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Debug.Log("Bullet - speed: " + speed);
        Rigidbody2D.velocity = Direction * speed;
    }

    public void SetDirection(Vector2 NewDirection, float newSpeed) {
        Direction = NewDirection;
        speed = newSpeed;
    }

    public void DestroyBullet() {
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        JohnMovement john = collision.collider.GetComponent<JohnMovement>();
        //If John is null, this collision not is against John
        if (john) john.Die();
        GruntMovement grunt = collision.collider.GetComponent<GruntMovement>();
        //If Grunt is null, this collision not is against Grunt
        if (grunt) grunt.Die();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
