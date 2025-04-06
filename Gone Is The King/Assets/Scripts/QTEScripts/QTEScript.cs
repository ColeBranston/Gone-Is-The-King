using UnityEngine;

public class QTESpinner : MonoBehaviour
{
    [Header("References")]
    public RectTransform spinnerNeedle;

    [Header("Settings")]
    public float rotationSpeed = 180f; // Degrees per second
    public float targetAngle = 152;
    public float successThreshold = 32;

    private bool qteActive = true;

    // Events
    public event System.Action OnQTESuccess;
    public event System.Action OnQTEFail;

    void Update()
    {
        if (!qteActive) return;

        spinnerNeedle.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            float currentAngle = spinnerNeedle.eulerAngles.z;
            float angleDiff = Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle));

            if (angleDiff <= successThreshold)
            {
                Debug.Log("✅ Success!");
                OnQTESuccess?.Invoke();
            }
            else
            {
                Debug.Log("❌ Fail!");
                OnQTEFail?.Invoke();
            }

            qteActive = false;
        }
    }

    public void ResetQTE()
    {
        qteActive = true;
        spinnerNeedle.localEulerAngles = Vector3.zero;
    }
}
