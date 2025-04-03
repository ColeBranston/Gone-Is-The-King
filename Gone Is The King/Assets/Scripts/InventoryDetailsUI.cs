using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDetailsUI : MonoBehaviour
{
    [SerializeField] private GameObject itemImageGO;  // The GameObject that holds the Image
    [SerializeField] private Image itemImage;           // The Image component on that GameObject
    [SerializeField] private TMP_Text itemNameText;       // The "Name: ..." field
    [SerializeField] private TMP_Text itemDescriptionText; // The "Description: ..." field

    /// <summary>
    /// Updates the details panel with the given item's info.
    /// Disables the image GameObject when no item is selected.
    /// </summary>
    public void ShowDetails(IItem item)
    {
        if (item != null)
        {
            // Enable the image GameObject and update its sprite
            if (itemImageGO != null)
                itemImageGO.SetActive(true);
            if (itemImage != null && item.Design != null)
                itemImage.sprite = item.Design;
            if (itemNameText != null)
                itemNameText.text = item.Name;
            if (itemDescriptionText != null)
                itemDescriptionText.text = item.Description;
        }
        else
        {
            // Disable the image GameObject to hide it
            if (itemImageGO != null)
                itemImageGO.SetActive(false);
            // Clear text fields
            if (itemNameText != null)
                itemNameText.text = "";
            if (itemDescriptionText != null)
                itemDescriptionText.text = "";
        }
    }
}
