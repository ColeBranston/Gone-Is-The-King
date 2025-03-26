using UnityEngine;

public class DialoguePopup : MonoBehaviour
{
    public float animationDuration = 0.3f;
    private Vector3 originalScale;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    void Awake()
    {
        RectTransform rect = GetComponent<RectTransform>();
        originalPosition = rect.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = gameObject.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -Screen.height);
    }

    public void Show()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateIn());
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateOut());
    }

    System.Collections.IEnumerator AnimateIn()
    {
        float t = 0;
        RectTransform rect = GetComponent<RectTransform>();
        Vector2 startPos = new Vector2(rect.anchoredPosition.x, -Screen.height);
        Vector2 endPos = originalPosition;

        while (t < animationDuration)
        {
            t += Time.deltaTime;
            float progress = t / animationDuration;
            canvasGroup.alpha = progress;
            rect.anchoredPosition = Vector2.Lerp(startPos, endPos, progress);
            yield return null;
        }

        canvasGroup.alpha = 1;
        rect.anchoredPosition = endPos;
    }

    System.Collections.IEnumerator AnimateOut()
    {
        float t = 0;
        RectTransform rect = GetComponent<RectTransform>();
        Vector2 startPos = rect.anchoredPosition;
        Vector2 endPos = new Vector2(rect.anchoredPosition.x, -Screen.height);

        while (t < animationDuration)
        {
            t += Time.deltaTime;
            float progress = t / animationDuration;
            canvasGroup.alpha = 1 - progress;
            rect.anchoredPosition = Vector2.Lerp(startPos, endPos, progress);
            yield return null;
        }

        canvasGroup.alpha = 0;
        rect.anchoredPosition = endPos;
    }
}