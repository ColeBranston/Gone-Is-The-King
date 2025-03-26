using JonathansDemo;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 0.4f;
    private Rigidbody2D rb; 
    private Vector2 movement; 

    void Start()
    {
        // Get the Rigidbody2D attached to the character
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // locks player movement when dialogue playing
        if (DialogueManager.DialogueIsPlaying)
            return;
        // Get input from arrow keys or WASD
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (DialogueManager.DialogueIsPlaying)
            return;
        // Apply movement to the Rigidbody2D
        rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "object"
        if (collision.gameObject.CompareTag("object"))
        {
            Debug.Log("Collided with an object!");
            // Example logic: Stop the player on collision
            rb.linearVelocity = Vector2.zero;

            // You can add additional behavior here as needed
        }
    }
}