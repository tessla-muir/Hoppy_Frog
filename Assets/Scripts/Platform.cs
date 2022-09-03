using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    public AudioSource jumpSound;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.y <= 0)
        {
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                jumpSound.Play();
            }
        }
    }
}
