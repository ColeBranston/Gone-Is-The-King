using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text notifyText;
    [SerializeField] private TMP_Text currentGold;

    private const int maxValue = 99;
    private const int minValue = 1; 

    public static ButtonHandler Instance;

    // Prefabs for items
    public GameObject swordPrefab;
    public GameObject crossbowPrefab;
    public GameObject herbPrefab;
    public GameObject healthPotionPrefab;
    public GameObject breadPrefab;
    public GameObject excaliburPrefab;

    // Track the selected item and quantity
    private GameObject selectedItemPrefab;
    private int counterValue = 1;

    void Awake()
    {
        Instance = this;
    }

    // This method is called every time the GUI becomes active.
    private void OnEnable()
    {
        UpdateCounterText();
    }

    private void Start()
    {
        UpdateCounterText();
    }

    // Called by the "+" button
    public void IncreaseCounter()
    {
        if (counterValue < maxValue)
            counterValue++;
        UpdateCounterText();
    }

    // Called by the "-" button
    public void DecreaseCounter()
    {
        if (counterValue > minValue)
            counterValue--;
        UpdateCounterText();
    }

    // Called by each item button
    public void SelectSword()
    {
        selectedItemPrefab = swordPrefab;
        Debug.Log("Sword Selected");
        UpdateCounterText();
    }
    
    public void SelectCrossbow()
    {
        selectedItemPrefab = crossbowPrefab;
        Debug.Log("Crossbow Selected");
        UpdateCounterText();
    }

    // ... repeat for other items
    public void SelectHerb()         { selectedItemPrefab = herbPrefab; Debug.Log("Herb Selected"); UpdateCounterText(); }
    public void SelectHealthPotion() { selectedItemPrefab = healthPotionPrefab; Debug.Log("Health Potion Selected"); UpdateCounterText(); }
    public void SelectBread()        { selectedItemPrefab = breadPrefab; Debug.Log("Bread Selected"); UpdateCounterText(); }
    public void SelectExcalibur()    { selectedItemPrefab = excaliburPrefab; Debug.Log("Lightsaber Selected"); UpdateCounterText(); }

    // Called by the "Buy" button
    public void BuyItem()
    {
        if (selectedItemPrefab == null)
        {
            Debug.LogError("No item selected to buy!");
            notifyText.SetText("No Item Selected");
            return;
        }

        // Get the IItem component from the prefab
        IItem itemComponent = selectedItemPrefab.GetComponent<IItem>();
        if (itemComponent == null)
        {
            Debug.LogError("Selected item prefab does not implement IItem!");
            return;
        }

        float totalPrice = itemComponent.Price * counterValue;
        if (CoinSystem.Instance.coins >= totalPrice)
        {
            CoinSystem.Instance.SpendCoins(totalPrice);

            Debug.Log("Bought item for " + totalPrice + " coins.");

            hasInventory.Instance.AddItem(itemComponent, counterValue);

            counterValue = 1;
            UpdateCounterText();
            
            notifyText.SetText("Purchased");
        }
        else
        {
            Debug.Log("Not enough coins to buy the item!");
            notifyText.SetText("Too Expensive");
        }
    }

    public void UpdateCounterText()
    {
        if (counterText != null)
        {
            currentGold.SetText($"Coins: {CoinSystem.Instance.coins}");
            counterText.SetText(counterValue.ToString());
            IItem itemComponent = selectedItemPrefab != null ? selectedItemPrefab.GetComponent<IItem>() : null;
            if (itemComponent != null)
            {
                priceText.SetText($"Price: {itemComponent.Price * counterValue} Coins");
            }
        }
    }
}
