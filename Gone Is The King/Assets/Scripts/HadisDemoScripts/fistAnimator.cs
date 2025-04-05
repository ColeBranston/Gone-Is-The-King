using UnityEngine;

public class FistAnimatorController : MonoBehaviour
{
    // Reference to the Animator component
    private Animator fistAnimator;

    // Offset distance for the fist movement
    public float punchOffset = 1f;

    // Duration for the fist to stay in the offset position
    public float punchDuration = 0.2f;

    // Damage dealt by the punch
    public int punchDamage = 10;

    // Original position of the fist
    private Vector3 originalPosition;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        fistAnimator = GetComponent<Animator>();

        // Store the original position of the fist
        originalPosition = transform.localPosition;

        // Check if the Animator component is found
        if (fistAnimator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    void Update()
    {
        // Check for mouse down (left-click)
        if (Input.GetMouseButtonDown(0))
        {
            // Trigger the animation using the "Punch" trigger parameter
            fistAnimator.SetTrigger("Punch");

            // Move the fist forward
            MoveFist();
        }
    }

    private void MoveFist()
    {
        // Move the fist in the forward direction
        transform.localPosition += transform.right * punchOffset;

        // Schedule returning the fist to its original position
        Invoke(nameof(ResetFistPosition), punchDuration);
    }

    private void ResetFistPosition()
    {
        // Reset the fist to its original position
        transform.localPosition = originalPosition;
    }

    // Called when another 2D collider enters this object's trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Here");
        // Check if the colliding object implements IAttackable (for example, an enemy)
        IAttackable attackable = other.GetComponent<IAttackable>();
        if (attackable != null)
        {
            // Apply damage to the enemy
            attackable.TakeDamage(punchDamage);
        }
    }
}
