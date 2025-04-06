using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    [Header("Scene Settings")]
    public int sceneToLoad; // Set this to the build index of the next scene

    [Header("QTE Settings")]
    public GameObject qtePanel; // Assign this to your Canvas
    private QTESpinner qteSpinner;

    [Header("QTE Success Settings")]
    public int requiredConsecutiveSuccesses = 3;
    private int currentConsecutiveSuccesses = 0;

    private bool playerInRange = false;

    void Start()
    {
        if (qtePanel != null)
        {
            qtePanel.SetActive(false);
            qteSpinner = qtePanel.GetComponentInChildren<QTESpinner>();
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (CheckConditions())
            {
                StartQTE();
            }
            else
            {
                Debug.Log("❌ Door conditions not met.");
            }
        }
    }

    private bool CheckConditions()
    {
        return GameManager.Instance != null && GameManager.Instance.bossComplete && GameManager.Instance.keyFound;
    }

    private void StartQTE()
    {
        if (qtePanel != null && qteSpinner != null)
        {
            qtePanel.SetActive(true);
            qteSpinner.ResetQTE();
            qteSpinner.OnQTESuccess += QTESuccess;
            qteSpinner.OnQTEFail += QTEFail;
        }
    }

    private void UnsubscribeQTEEvents()
    {
        qteSpinner.OnQTESuccess -= QTESuccess;
        qteSpinner.OnQTEFail -= QTEFail;
    }

    private void QTESuccess()
    {
        currentConsecutiveSuccesses++;
        UnsubscribeQTEEvents();
        qtePanel.SetActive(false);

        if (currentConsecutiveSuccesses == requiredConsecutiveSuccesses)
        {
            Debug.Log("✅ QTE Passed. Loading next scene...");
            GameManager.Instance.CompletedBoss(false);
            GameManager.Instance.FoundKey(false);
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            StartCoroutine(RestartQTE());
        }
    }

    private void QTEFail()
    {
        currentConsecutiveSuccesses = 0;
        UnsubscribeQTEEvents();
        qtePanel.SetActive(false);
        StartCoroutine(RestartQTE());
    }

    private IEnumerator RestartQTE()
    {
        yield return new WaitForSeconds(1f);
        StartQTE();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInRange = false;
    }
}