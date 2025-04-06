using UnityEngine;

public class EnemyBoss : MonoBehaviour, IAttackable
{
    // Use private backing fields for health and defense.
    [SerializeField]
    private double _health = 100; // You can set an initial value here or via the inspector

    [SerializeField]
    private double _defense = 10; // Likewise, set an initial value

    // Public properties to access health and defense
    public double Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public double Defense
    {
        get { return _defense; }
        set { _defense = value; }
    }

    public float moveSpeed = 3f;           // Movement speed of the enemy boss
    public float attackRange = 1f;         // Range at which the boss will attack
    public float detectionRange = 5f;      // Range at which the boss will detect the player
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

        // Check for death
        if (Health <= 0f)
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

    // This function is called when the player's collider stays within the boss's trigger collider
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
    public void TakeDamage(double damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;

        Debug.Log("Boss Health: " + Health);
    }

    // Handle the boss death
    private void Die()
    {
        Debug.Log("Boss has been defeated!");
        Destroy(gameObject); // Destroy the boss object when it dies
    }
}
