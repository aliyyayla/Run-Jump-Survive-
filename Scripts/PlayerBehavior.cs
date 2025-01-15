using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float jumpForce = 5f; // Adjust this to control jump height
    private Rigidbody2D rb; // Reference to Rigidbody2D
    private bool isGrounded; // Check if the character is on the ground
    private Vector2 initialPosition; // Store the initial position to keep the character fixed

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Set the initial position of the character
        initialPosition = transform.position;

        // Assume the player starts on the ground
        isGrounded = true;
    }

    void Update()
    {
        // Prevent the character from moving left or right
        transform.position = new Vector2(initialPosition.x, transform.position.y);

        // Jump when the space bar is pressed, and the character is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(0, jumpForce); // Apply vertical jump force
            isGrounded = false; // Prevent multiple jumps
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character landed back on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Allow jumping again
        }
    }
}

