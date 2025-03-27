using UnityEngine;

public class FistFollowAndRotate : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private static Transform playerTransform; // Assign the player's transform
    [SerializeField] private Camera mainCamera;         // Assign the main camera (optional)

    private void Start()
    {
        // If no camera is assigned, use Camera.main.
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        // Lock the fist's position to the player's x and y.
        // Optionally, preserve its z-position if needed (e.g., for sorting order)
        Vector3 newPosition = playerTransform.position;
        newPosition.z = transform.position.z; 
        transform.position = newPosition;

        // Get the mouse position in world coordinates.
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        mousePosition.z = transform.position.z; // Ensure z is consistent

        // Calculate the direction from the player to the mouse.
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle (in degrees) required for the rotation.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation so the fist points toward the mouse.
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public static void setPlayer(GameObject player){
        playerTransform = player.transform;
    }
}
