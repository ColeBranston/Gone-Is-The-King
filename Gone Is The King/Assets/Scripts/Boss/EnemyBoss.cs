using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public float moveSpeed = 3f;           // Movement speed of the enemy boss
    public float attackRange = 1f;         // Range at which the boss will attack
    public float detectionRange = 5f;      // Range at which the boss will detect the player
    public float health = 100f;            // Health of the boss
    public float damage = 10f;             // Damage dealt by the boss
    private float attackCooldown = 1f;     // Time between attacks
    private float attackCooldownTimer = 0f;

    private Transform player;              // Player's transform (will be set dynamically)

    private void Update()
    {
        // If player is found, handle movement
        if (player != null)
        {
            // Check if the player is within detection range
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance < detectionRange)
            {
                MoveTowardsPlayer();
            }
        }

        // Update attack cooldown timer
        if (attackCooldownTimer > 0f)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        if (health <= 0f)
        {
            Die();
        }
    }

    // Move the boss towards the player
    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    // This function will be called when the player's collider enters the boss's attack range
    private void OnTriggerStay2D(Collider2D other)
    {
        // When the boss collider detects the player, store the player's transform dynamically
        if (other.CompareTag("Player"))
        {
            player = other.transform; // Get player transform dynamically from the collider

            if (attackCooldownTimer <= 0f)
            {
                // Apply damage to player
                Debug.Log("Boss is attacking the player!");
                HealthSystem.Instance.TakeDamage(damage);

                // Reset attack cooldown
                attackCooldownTimer = attackCooldown;
            }
        }
    }

    // Take damage from the player or other sources
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0) health = 0;

        Debug.Log("Boss Health: " + health);
    }

    // Handle the boss death
    private void Die()
    {
        Debug.Log("Boss has been defeated!");
        Destroy(gameObject); // Destroy the boss object when it dies
    }
}
