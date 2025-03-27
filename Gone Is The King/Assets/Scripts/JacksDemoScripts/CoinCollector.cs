using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        // Check if the object has the tag "experiencePoints"
        if (collision.gameObject.CompareTag("coins"))
        {
            // Example XP amount (you can customize this as needed)
            float money = 5f;

            if (CoinSystem.Instance != null)
            {
                CoinSystem.Instance.AddCoins(money); // Add experience via HealthSystem
                Debug.Log($"Collected {money} money! current money: {CoinSystem.Instance.coins}");
            }
            else
            {
                Debug.LogError("Coin System instance not found!");
            }

            // Destroy the object after collecting experience
            Destroy(collision.gameObject);
        }
    }
}