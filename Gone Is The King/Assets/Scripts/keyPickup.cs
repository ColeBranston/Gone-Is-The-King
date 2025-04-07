using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [Header("Key Type")]
    public bool isRealKey = false;  // Check this in the Inspector for the real key

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRealKey)
            {
                GameManager.Instance.FoundKey(true);  // Call method if it's the real key
                Debug.Log("🔑 Real key picked up!");
            }
            else
            {
                Debug.Log("❌ Fake key picked up.");
            }

            Destroy(gameObject); // Either way, remove the key object
        }
    }
}