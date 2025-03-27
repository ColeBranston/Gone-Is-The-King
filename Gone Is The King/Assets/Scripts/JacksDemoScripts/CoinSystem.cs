using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    public static CoinSystem Instance;
    public Text coinText; // Reference to the Text UI element
    public float coins = 0f; // Keeps track of the coin count

    void Awake()
    {
        Instance = this;
    }
    
    // Function to add coins
    public void AddCoins(float amount)
    {
        coins += amount; // Increase the coin count
        UpdateText(); // Update the UI
        Debug.Log(amount + " coins added. Total coins: " + coins);
    }

    // Function to spend coins
    public bool SpendCoins(float amount)
    {
        if (coins >= amount)
        {
            coins -= amount; // Deduct the coin count
            UpdateText(); // Update the UI
            Debug.Log(amount + " coins spent. Remaining coins: " + coins);
            return true; // Transaction successful
        }
        else
        {
            Debug.Log("Not enough coins! Current balance: " + coins);
            return false; // Transaction failed
        }
    }

    // Method to update the coin text in the specific format
    private void UpdateText()
    {
        if (coinText != null)
        {
            coinText.text = $"Coins: {(int) coins}"; // Displays coins in "Coins: <coins>" format with two decimal places
        }
    }
}