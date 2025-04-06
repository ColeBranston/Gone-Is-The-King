using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Reference to the nested Inventory GUI GameObject (instantiated as part of the character prefab)
    private GameObject inventoryGUI;

    // Flag to indicate if the inventory GUI is active
    public bool activeGUI = false;

    public static InventoryController Instance;

    void Awake()
    {
        Instance = this;

        // Attempt to find the nested Inventory GUI by name "InventoryGUI"
        Transform guiTransform = transform.Find("InventoryGUI");
        if (guiTransform != null)
        {
            inventoryGUI = guiTransform.gameObject;
            // Ensure it is hidden at the start
            inventoryGUI.SetActive(false);
            Debug.Log("Inventory GUI found and set to inactive.");
        }
        else
        {
            Debug.LogWarning("Inventory GUI not found! Ensure the child is named 'InventoryGUI'.");
        }
    }

    void Update()
    {
        // Check if the player presses the "I" key
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Prevent toggling the inventory if the shop is active
            if (ShopTrigger.Instance != null && ShopTrigger.Instance.IsShopActive())
            {
                Debug.Log("Cannot open inventory while shop is active.");
                return;
            }

            if (inventoryGUI != null)
            {
                bool isActive = inventoryGUI.activeSelf;
                inventoryGUI.SetActive(!isActive);
                activeGUI = !isActive;
                Debug.Log("Inventory GUI toggled to " + (inventoryGUI.activeSelf ? "active." : "inactive."));
            }
            else
            {
                Debug.LogError("Inventory GUI reference is missing! Cannot toggle visibility.");
            }
        }
    }
}
