using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public AudioSource deathSound;
    private float movement;

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

        // Left movement
        if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = true;
        }

        // Right movement
        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
        }
    }

    void FixedUpdate()
    {
        // Update movement in the x
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Player fell off the screen
        if (other.tag == "Death Collider")
        {
            Debug.Log("Collided!");
            deathSound.Play();
            StartCoroutine(ChangeToScene(2f));
        }
    }

    IEnumerator ChangeToScene(float delay)
    {
        // Waits for death sound to play before changing to next game
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("EndMenu");
    }
}
