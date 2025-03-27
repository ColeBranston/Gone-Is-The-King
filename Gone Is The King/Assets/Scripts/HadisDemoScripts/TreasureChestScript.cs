using UnityEngine;

public class TreasureChestScript : MonoBehaviour
{
    // Sprite references to assign in the Inspector
    public Sprite closedSprite;
    public Sprite openSprite;

    // Amount of coins this chest gives
    public float coinReward = 5f;

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;
    private bool playerInRange = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite;
    }

    void Update()
    {
        // When the chest is not open, player is in range and E is pressed, open the chest
        if (!isOpen && playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        isOpen = true;
        spriteRenderer.sprite = openSprite;

        // Add coins using your coin system
        if (CoinSystem.Instance != null)
        {
            CoinSystem.Instance.AddCoins(coinReward);
            Debug.Log($"Collected {coinReward} coins! Current coins: {CoinSystem.Instance.coins}");
        }
        else
        {
            Debug.LogError("CoinSystem instance not found!");
        }
    }

    // Using trigger detection for player proximity
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
