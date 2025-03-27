using UnityEngine;

public class ExperienceCollector2D : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        // Check if the object has the tag "experiencePoints"
        if (collision.gameObject.CompareTag("experiencePoints"))
        {
            // Example XP amount (you can customize this as needed)
            float xpAmount = 10f;

            if (HealthSystem.Instance != null)
            {
                HealthSystem.Instance.RestoreExperience(xpAmount); // Add experience via HealthSystem
                Debug.Log($"Collected {xpAmount} XP! Current XP: {HealthSystem.Instance.ExperiencePoint}, Level: {HealthSystem.Instance.level}");
            }
            else
            {
                Debug.LogError("HealthSystem instance not found!");
            }

            // Destroy the object after collecting experience
            Destroy(collision.gameObject);
        }
    }
}