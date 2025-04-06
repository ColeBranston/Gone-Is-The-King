using UnityEngine;

public class FistAnimatorController : MonoBehaviour
{
    // Reference to the Animator component
    private Animator fistAnimator;

    // Offset distance for the fist movement
    public float punchOffset = 1f;

    // Damage dealt by the punch
    public int punchDamage = 10;

    // Original position of the fist
    private Vector3 originalPosition;

    // Flag to track if the punch is active
    private bool isPunching = false;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        fistAnimator = GetComponent<Animator>();

        // Store the original position of the fist
        originalPosition = transform.localPosition;

        if (fistAnimator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    void Update()
    {
        // Start punch on left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            fistAnimator.SetTrigger("Punch");
            StartPunch();
        }
    }

    // Called at the start of the punch animation
    private void StartPunch()
    {
        isPunching = true;
        // Optionally move the fist forward instantly (or handle via the animation)
        transform.localPosition += transform.right * punchOffset;
    }

    // This method is meant to be called by an animation event at the end of the punch animation
    public void EndPunch()
    {
        isPunching = false;
        // Reset the fist to its original position once the animation finishes
        transform.localPosition = originalPosition;
    }

    // Called when another 2D collider enters this object's trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only apply damage if the punch is active
        if (!isPunching)
            return;

        IAttackable attackable = other.GetComponent<IAttackable>();
        if (attackable != null)
        {
            attackable.TakeDamage(punchDamage);
        }
    }
}
