using System.Net.NetworkInformation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    // Example variables you might track
    public int bossesSpared = 0;
    public int bossesFought = 0;

    // Public for testing
    public bool bossComplete = false;
    public bool keyFound = false;

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }
        
        // Set this as the singleton instance
        Instance = this;

        // Make sure the GameManager persists across scenes
        DontDestroyOnLoad(gameObject);
    }

    // Methods to update boss stats
    public void RecordSpare()
    {
        bossesSpared++;
        Debug.Log("Boss spared. Total spared: " + bossesSpared);
    }

    public void RecordFight()
    {
        bossesFought++;
        Debug.Log("Boss fought. Total fought: " + bossesFought);
    }
    public void CompletedBoss(bool value){
        bossComplete = value;
    }
    public void FoundKey(bool value){
        keyFound = value;
    }    
}
