using JonathansDemo;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.4f;
    public float dashCooldown = 1f;
    public bool canDash = false;

    private bool isDashing = false;
    private float dashTimeLeft;
    private float lastDashTime = -Mathf.Infinity;
    private Vector2 dashDirection;

    private Rigidbody2D rb; 
    private Vector2 movement; 

    public static playerMovement Instance;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist through scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }
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

        if (canDash && Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDashTime + dashCooldown)
        {
            isDashing = true;
            dashTimeLeft = dashDuration;
            dashDirection = movement.normalized != Vector2.zero ? movement.normalized : Vector2.up;
            lastDashTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        if (DialogueManager.DialogueIsPlaying)
            return;
        // Apply movement to the Rigidbody2D
        if (isDashing)
        {
            rb.MovePosition(rb.position + dashDirection * (dashSpeed * Time.fixedDeltaTime));
            dashTimeLeft -= Time.fixedDeltaTime;
            if (dashTimeLeft <= 0f)
            {
                isDashing = false;
            }
        }
        else
        {
            rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
        }
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
    public void UnlockDash(){
        canDash = true;
    }
}