using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Needed for scene loading
using JonathansDemo;

public class RoyalAdvisorDecisionHandler : MonoBehaviour
{
    [Header("Choice UI")]
    public GameObject choicePanel;
    public Button spareButton;
    public Button fightButton;

    [Header("Transforms")]
    public GameObject enemyVersion;   

    private bool playerInRange = false;
    private bool hasDecided = false;

    private void Start()
    {
        choicePanel.SetActive(false);
        spareButton.onClick.AddListener(Spare);
        fightButton.onClick.AddListener(Fight);
    }

    private void Update()
    {
        if (playerInRange && !hasDecided && Input.GetKeyDown(KeyCode.E))
        {
            if (choicePanel != null)
            {
                choicePanel.SetActive(true);
                Debug.Log("📋 Royal Advisor choice panel opened.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ Player entered the Royal Advisor trigger zone!");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🚪 Player left the Royal Advisor trigger zone.");
            playerInRange = false;
        }
    }

    private void Spare()
    {
        GameManager.Instance.RecordSpare();
        choicePanel.SetActive(false);
        hasDecided = true;

        // Go to the ending scene for sparing the Royal Advisor
        SceneManager.LoadScene("ConvictSuspectsEnding");
    }

    private void Fight()
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
