using UnityEngine;

public class animationController : MonoBehaviour
{
    private Animator animator;
    private float xWalking; // -1 for left, 1 for right, 0 for no horizontal movement
    private float yWalking; // -1 for down, 1 for up, 0 for no vertical movement

    // Start is called before the first execution of Update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from both arrow keys and WASD using Axis
        xWalking = Input.GetAxisRaw("Horizontal"); // Returns -1, 0, or 1
        yWalking = Input.GetAxisRaw("Vertical");   // Returns -1, 0, or 1

        // Update Animator parameters
        animator.SetInteger("xWalking", Mathf.RoundToInt(xWalking));
        animator.SetInteger("yWalking", Mathf.RoundToInt(yWalking));
    }
}