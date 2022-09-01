using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;

    float movement = 0f;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
  
    void Update()
    {
       movement = Input.GetAxis("Horizontal") * movementSpeed;

       // Left
        if (Input.GetAxis("Horizontal") < 0) {
            sprite.flipX = true;
        }

       // Right
        if (Input.GetAxis("Horizontal") > 0) {
            sprite.flipX = false;
        }
    }

    void FixedUpdate() 
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
    
}
