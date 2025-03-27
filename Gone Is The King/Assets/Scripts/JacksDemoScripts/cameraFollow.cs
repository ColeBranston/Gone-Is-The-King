using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float smoothSpeed; // Speed of camera movement
    public Vector3 offset; // Offset to maintain distance from the player

    void LateUpdate()
    {
        if (player == null) return;

        // Desired position for the camera (keep Z constant for 2D)
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, -5);

        // Smoothly transition to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public void SetPlayer(GameObject newPlayer)
    {
        if (newPlayer != null)
        {
            player = newPlayer.transform; // Set the player's Transform
        }
    }
}