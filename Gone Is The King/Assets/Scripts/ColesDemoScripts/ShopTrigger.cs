using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopMenu; // The shop menu UI
    private bool playerNearShop = false; // Tracks if the player is near the shop

    public static ShopTrigger Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Ensure the shop menu is hidden at the start
        if (shopMenu != null)
        {
            shopMenu.SetActive(false);
        }
    }

    // Helper method to check if the shop menu is active
    public bool IsShopActive()
    {
        return shopMenu != null && shopMenu.activeSelf;
    }

    void Update()
    {
        // Check if the player is near the shop and presses E
        if (playerNearShop && Input.GetKeyDown(KeyCode.E))
        {
            // Prevent shop GUI from opening if the inventory GUI is active
            if (InventoryController.Instance != null && InventoryController.Instance.activeGUI)
            {
                Debug.Log("Cannot open shop because Inventory GUI is active.");
                return;
            }

            if (shopMenu != null)
            {
                // Toggle the shop menu's visibility
                bool isActive = shopMenu.activeSelf;
                shopMenu.SetActive(!isActive);
                Debug.Log("Shop menu toggled to " + (shopMenu.activeSelf ? "active." : "inactive."));
            }
            else
            {
                Debug.LogError("Shop menu reference is missing!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detect when the player enters the shop's interaction zone
        if (other.CompareTag("Player"))
        {
            playerNearShop = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Detect when the player leaves the shop's interaction zone
        if (other.CompareTag("Player"))
        {
            playerNearShop = false;

            // Automatically hide the shop menu if the player moves away
            if (shopMenu != null && shopMenu.activeSelf)
            {
                shopMenu.SetActive(false);
            }
        }
    }
}
