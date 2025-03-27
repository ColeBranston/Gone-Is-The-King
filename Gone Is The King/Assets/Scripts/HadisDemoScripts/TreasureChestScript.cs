using UnityEngine;
using JonathansDemo;

public class TreasureChestScript : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;
    private bool playerInRange = false;

    // Reference to the dialogue script (make sure both scripts are on the same GameObject)
    private DialogueNPCScript dialogueScript;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite;
        dialogueScript = GetComponent<DialogueNPCScript>();
    }

    void Update()
    {
        if (!isOpen && playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
            // Trigger dialogue when chest is opened
            dialogueScript?.OnSpokenTo();
        }
    }

    private void OpenChest()
    {
        isOpen = true;
        spriteRenderer.sprite = openSprite;
        // Optional: add more chest logic here
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
