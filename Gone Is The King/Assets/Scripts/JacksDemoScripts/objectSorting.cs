using UnityEngine;

public class objectSorting : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Dynamically adjust sorting order based on player's y-position
        spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100); // Adjust multiplier as needed
        // Debug.Log(spriteRenderer.sortingOrder);
    }
}