using UnityEngine;
using UnityEngine.UI;
using JonathansDemo;

public class RoyalAdvisorDecisionHandler : MonoBehaviour
{
    [Header("Choice UI")]
    public GameObject choicePanel;
    public Button convictSuspect;
    public Button convictAdvisor;
    GameManager gameManager;

    [Header("Transforms")]
    public GameObject enemyVersion;   
    private bool playerInRange = false;
    private bool hasDecided = false;

    private void Start()
    {
        choicePanel.SetActive(false);
        convictSuspect.onClick.AddListener(ConvictSuspects);
        if(gameManager.bossesFought == 0){
            convictAdvisor.onClick.AddListener(ConvictAdvisor);
        }
        
    }

     void Update()
    {
        if (playerInRange && !hasDecided && Input.GetKeyDown(KeyCode.E))
        {
            if (choicePanel != null)
            {
                choicePanel.SetActive(true);
                Debug.Log("📋 Boss choice panel opened.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ Player entered the boss trigger zone!");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🚪 Player left the boss trigger zone.");
            playerInRange = false;
        }
    }

    private void ConvictSuspects()
{
    
}

private void ConvictAdvisor()
{
    GameManager.Instance.RecordFight();
    choicePanel.SetActive(false);
    hasDecided = true;

    if (enemyVersion != null)
    {
        Instantiate(enemyVersion, transform.position, transform.rotation);
    }

    Destroy(gameObject); // remove neutral boss
}
}