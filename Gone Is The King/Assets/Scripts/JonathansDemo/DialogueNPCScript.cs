using JonathansDemo;
using UnityEngine;

public class DialogueNPCScript : MonoBehaviour
{
    public Dialogue dialogue; // assign in the Inspector

    public void OnSpokenTo()
    {
        if (!DialogueManager.DialogueIsPlaying)
        {
            FindFirstObjectByType<DialogueManager>()?.StartDialogue(dialogue);
        }
    }
}