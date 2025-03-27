using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText; // Serialized field
    private const int maxValue = 99;
    private const int minValue = 0;

    public void OnButtonClicked()
    {
        Debug.Log("Button Has Been Clicked");
        
        if (counterText == null)
        {
            Debug.LogError("Counter Text is not assigned to the script!");
            return;
        }

        // Read current value from text and convert it to an integer
        int counterValue;
        if (!int.TryParse(counterText.text, out counterValue))
        {
            Debug.LogError("Counter Text does not contain a valid integer!");
            return;
        }

        switch (this.gameObject.tag)
        {
            case "Increase":
                if (counterValue < maxValue) counterValue++;
                break;
            case "Decrease":
                if (counterValue > minValue) counterValue--;
                break;
            case "Buy":
                counterValue = 0;
                break;
            default:
                Debug.LogWarning($"Unrecognized button tag: {this.gameObject.tag}");
                return;
        }

        // Update counter text
        counterText.SetText(counterValue.ToString());
    }
}
