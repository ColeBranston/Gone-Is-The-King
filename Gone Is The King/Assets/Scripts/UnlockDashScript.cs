using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    IEnumerator Start()
    {
        // Wait until PlayerMovement.Instance is ready
        while (playerMovement.Instance == null)
        {
            yield return null;
        }

        playerMovement.Instance.UnlockDash();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
