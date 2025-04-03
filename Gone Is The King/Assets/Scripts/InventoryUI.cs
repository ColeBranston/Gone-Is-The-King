using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private hasInventory playerInventory;  // Assign the GameObject with the hasInventory component in the Inspector.
    [SerializeField] private GameObject itemSlotPrefab;       // Assign your InventoryItemSlot prefab.
    [SerializeField] private Transform contentParent;         // Assign the "Content" object of your Scroll View.
    [SerializeField] private InventoryDetailsUI detailsPanelInScene; // Assign the details panel (scene object) here

    private void OnEnable()
    {
        // Subscribe to the inventory change event.
        if (playerInventory != null)
        {
            playerInventory.OnInventoryChanged += RefreshInventoryUI;
            // Do an initial refresh.
            RefreshInventoryUI();
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from the inventory change event.
        if (playerInventory != null)
        {
            playerInventory.OnInventoryChanged -= RefreshInventoryUI;
        }
    }

    /// <summary>
    /// Clears the content area and rebuilds the UI for each item in the player's inventory.
    /// </summary>
    public void RefreshInventoryUI()
    {
        Debug.Log("Inventory GUI Refreshed");

        // 1. Clear existing slots.
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // 2. Loop through the inventory items.
        if (playerInventory != null)
        {
            // Retrieve a copy of the inventory dictionary.
            var items = playerInventory.GetAllItems();

            foreach (var kvp in items)
            {
                // kvp.Key is the item's name (a string) but we want the actual IItem and the quantity from kvp.Value.
                var (item, amount) = kvp.Value;

                // 3. Instantiate a new item slot as a child of the content parent.
                GameObject slotGO = Instantiate(itemSlotPrefab, contentParent);

                // 4. Set the UI data using the InventoryItemSlotUI script on the prefab.
                var slotUI = slotGO.GetComponent<InventoryItemSlotUI>();
                if (slotUI != null)
                {
                    slotUI.SetItemData(item, amount);
                    slotUI.SetDetailsPanel(detailsPanelInScene);
                }
            }
        }
    }
}
