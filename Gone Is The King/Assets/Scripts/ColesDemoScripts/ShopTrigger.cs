using UnityEngine;

public class ShopTriggerWithMenu : MonoBehaviour
{
    public GameObject shopMenu; // The shop menu UI
    private bool playerNearShop = false; // Tracks if the player is near the shop

    void Start()
    {
        // Make sure the shop menu is hidden at the start
        if (shopMenu != null)
        {
            shopMenu.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the player is near the shop and presses E
        if (playerNearShop && Input.GetKeyDown(KeyCode.E))
        {
            if (shopMenu != null)
            {
                // Toggle the shop menu's visibility
                bool isActive = shopMenu.activeSelf;
                shopMenu.SetActive(!isActive);
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