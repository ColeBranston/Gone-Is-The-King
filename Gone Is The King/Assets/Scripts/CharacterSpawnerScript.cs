using UnityEngine;
using System.Collections;

public class CharacterSpawnerScript : MonoBehaviour
{
    void Start()
    {
        // Start the coroutine to instantiate the selected character after the scene is loaded
        StartCoroutine(InstantiateCharacter());
    }

    private IEnumerator InstantiateCharacter(){
    yield return null; // Wait until the next frame to ensure everything is ready

    GameObject selectedCharacter = MenuScript.GetSelectedCharacter();
    if (selectedCharacter != null){
            // Instantiate the selected character at the position and rotation of this GameObject
            GameObject instantiatedCharacter = Instantiate(selectedCharacter, transform.position, transform.rotation);

            // Set the player in FistFollowAndRotate script
            FistFollowAndRotate.setPlayer(instantiatedCharacter);

            // Find the CameraFollow script (assuming it's on the main camera)
            cameraFollow cameraFollow = Camera.main.GetComponent<cameraFollow>();
            if (cameraFollow != null){
            // Pass the instantiated character to the camera to follow
            cameraFollow.SetPlayer(instantiatedCharacter);
            }
            else{
            Debug.LogError("CameraFollow not found on the main camera.");   
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
