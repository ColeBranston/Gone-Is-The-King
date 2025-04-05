using UnityEngine;

public class QTESpinner : MonoBehaviour
{
    [Header("References")] public RectTransform spinnerNeedle;

    [Header("Settings")] public float rotationSpeed = 180f; // Degrees per second
    public float targetAngle = 152; // 152          // Angle where E must be pressed
    public float successThreshold = 32; // 32     // Allowed margin (degrees)

    private bool qteActive = true;

    void Update()
    {
        if (!qteActive) return;

        // Rotate the spinner clockwise
        spinnerNeedle.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        // Debug.Log("Angle: " + spinnerNeedle.eulerAngles.z); // to check the angles for Debuging


        if (Input.GetKeyDown(KeyCode.E))
        {
            float currentAngle = spinnerNeedle.eulerAngles.z;
            float angleDiff = Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle));

            if (angleDiff <= successThreshold)
            {
                Debug.Log("✅ Success!");
                // Add your success logic here
            }
            else
            {
                Debug.Log("❌ Fail!");
                // Add your fail logic here
            }
            qteActive = false; // Only allow one press; remove this if it's multi-try
        }
    }
}