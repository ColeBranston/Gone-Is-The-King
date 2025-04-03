using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryItemSlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text quantityText;

    // Reference to the details panel (assign via Inspector or set at runtime)
    [SerializeField] private InventoryDetailsUI detailsPanel;

    private IItem currentItem;
    private int currentAmount;

    public void SetItemData(IItem item, int amount)
    {
        currentItem = item;
        currentAmount = amount;
        
        // Update UI elements
        if (itemIcon != null && item.Design != null)
            itemIcon.sprite = item.Design;

        if (itemNameText != null)
            itemNameText.text = $"Name: {item.Name}";

        if (quantityText != null)
            quantityText.text = $"Quantity: {amount}";
    }

    public void SetDetailsPanel(InventoryDetailsUI panel)
    {
        detailsPanel = panel;
    }


    /// <summary>
    /// Called when this slot is clicked.
    /// </summary>
    /// <param name="eventData">Pointer event data.</param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (detailsPanel != null && currentItem != null)
        {
            detailsPanel.ShowDetails(currentItem);
        }
    }
}
