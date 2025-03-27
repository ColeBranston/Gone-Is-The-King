using System;
using JonathansDemo;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject promptText;
    private bool playerNearNPC = false;
    private Vector3 promptOffset;

    public float interactionRange = 2f; // for the circles range
    public LayerMask npcLayerMask;

    void Start()
    {
        if (promptText != null)
        {
            promptOffset = promptText.transform.localPosition;
            promptText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (promptText != null && playerNearNPC)
        {
            float bob = Mathf.Sin(Time.time * 4f) * 0.1f;
            promptText.transform.localPosition = promptOffset + new Vector3(0, bob, 0);
        }

        if (playerNearNPC && Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRange, npcLayerMask);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("DialogueNPC"))
                {
                    DialogueNPCScript npc = hitCollider.GetComponent<DialogueNPCScript>();
                    if (npc != null)
                    {
                        npc.OnSpokenTo();
                        break;
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DialogueNPC"))
        {
            playerNearNPC = true;
            if (promptText != null) promptText.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DialogueNPC"))
        {
            playerNearNPC = false;
            if (promptText != null) promptText.SetActive(false);
        }
    }
}