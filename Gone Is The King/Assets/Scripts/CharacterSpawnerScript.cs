using UnityEngine;
using System.Collections;

public class CharacterSpawnerScript : MonoBehaviour
{
    void Start()
    {
        // Start the coroutine to instantiate or move the character to the spawn point
        StartCoroutine(InstantiateOrMoveCharacter());
    }

    private IEnumerator InstantiateOrMoveCharacter()
    {
        yield return null; // Wait until the next frame to ensure everything is ready

        // Check if a player already exists in the scene (because of DontDestroyOnLoad)
        GameObject existingPlayer = FindObjectOfType<playerMovement>()?.gameObject;

        if (existingPlayer != null)
        {
            Debug.Log("⚠ Player already exists. Moving the player to the spawn point.");
            // Move the existing player to the spawn position
            existingPlayer.transform.position = transform.position;

            // Optionally, you can reset any other properties, like rotation, if needed
            existingPlayer.transform.rotation = transform.rotation;

            // If you need to reset specific components or behaviors, do that here
            FistFollowAndRotate.setPlayer(existingPlayer);

            cameraFollow cameraFollow = Camera.main.GetComponent<cameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.SetPlayer(existingPlayer);
            }
            else
            {
                Debug.LogError("CameraFollow not found on the main camera.");
            }

            yield break; // Stop the coroutine, as the player has been moved
        }

        // If no player exists, instantiate a new one
        GameObject selectedCharacter = MenuScript.GetSelectedCharacter();
        if (selectedCharacter != null)
        {
            // Instantiate the character at the spawner's position and rotation
            GameObject instantiatedCharacter = Instantiate(selectedCharacter, transform.position, transform.rotation);

            // Optional: if the prefab doesn't already call DontDestroyOnLoad in Awake
            DontDestroyOnLoad(instantiatedCharacter);

            // Set sorting order for any child sprite renderers
            SpriteRenderer[] spriteRenderers = instantiatedCharacter.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sr in spriteRenderers)
            {
                sr.sortingOrder = 3;
            }

            // Set the player reference in other components
            FistFollowAndRotate.setPlayer(instantiatedCharacter);

            cameraFollow cameraFollow = Camera.main.GetComponent<cameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.SetPlayer(instantiatedCharacter);
            }
            else
            {
                Debug.LogError("CameraFollow not found on the main camera.");
            }
        }
        else
        {
            Debug.LogError("Selected character prefab is null.");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
