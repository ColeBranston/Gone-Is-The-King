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

        // Start is called once before the first execution of Update after the MonoBehaviour is created
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
                    return;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    DisplayNextSentence();
                }
            }
        }

        public void StartDialogue(Dialogue dialogue)
        {
            DialogueIsPlaying = true;
            justStartedDialogue = true;
            dialoguePopup.Show();

            nameText.text = dialogue.name;
            
            // Set portrait image
            if (portraitImage != null)
            {
                portraitImage.sprite = dialogue.portrait;
                portraitImage.enabled = dialogue.portrait != null; // Hide if none assigned
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
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            yield return new WaitForSeconds(0.1f);
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.045f);
            }
        }

        public void EndDialogue()
        {
            Debug.Log("End of Convo");
            dialoguePopup.Hide();
            DialogueIsPlaying = false;
        }
    }
}