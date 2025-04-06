using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    // Example variables you might track
    public int bossesSpared = 0;
    public int bossesFought = 0;

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
}
