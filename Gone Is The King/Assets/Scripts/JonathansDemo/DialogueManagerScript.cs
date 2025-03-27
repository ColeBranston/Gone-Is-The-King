using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JonathansDemo
{
    public class DialogueManager : MonoBehaviour
    {
        public TMP_Text nameText;
        public TMP_Text dialogueText;
        public Image portraitImage;
        public DialoguePopup dialoguePopup;

        private Queue<string> sentences;
        public static bool DialogueIsPlaying = false;
        private bool justStartedDialogue = false;
        private float endDialogueDelay = 0.1f; // Delay in seconds after the dialogue ends

        void Start()
        {
            sentences = new Queue<string>();
        }

        void Update()
        {
            if (DialogueIsPlaying)
            {
                if (justStartedDialogue)
                {
                    justStartedDialogue = false;
                    return; // Prevent input during the first frame of the dialogue
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    DisplayNextSentence();
                }
            }
        }

        public void StartDialogue(Dialogue dialogue)
        {
            if (DialogueIsPlaying)
            {
                Debug.LogWarning("Dialogue is already playing. Ignoring StartDialogue call.");
                return; // Prevent starting a new dialogue while one is active
            }

            DialogueIsPlaying = true;
            justStartedDialogue = true;
            dialoguePopup.Show();

            nameText.text = dialogue.name;

            // Set portrait image
            if (portraitImage != null)
            {
                portraitImage.sprite = dialogue.portrait;
                portraitImage.enabled = dialogue.portrait != null;
            }

            sentences.Clear();

            foreach (string sentence in dialogue.sentence)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                StartCoroutine(EndDialogueWithDelay()); // Trigger delayed ending
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines(); // Stop any ongoing typing coroutine
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.045f);
            }
        }

        IEnumerator EndDialogueWithDelay()
        {
            Debug.Log("End of Conversation. Dialogue will stop after a delay.");
            yield return new WaitForSeconds(endDialogueDelay); // Wait for the specified delay
            EndDialogue();
        }

        public void EndDialogue()
        {
            Debug.Log("Dialogue has been stopped.");
            dialoguePopup.Hide();
            DialogueIsPlaying = false; // Ensure flag is reset
            justStartedDialogue = false; // Reset this state as well
        }
    }
}