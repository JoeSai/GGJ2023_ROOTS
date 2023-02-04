using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public float animationDuration = 1.0f;
    public AnimationCurve animationCurve;
    public RectTransform rectTransform;

    public float showDuration = 5f;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(ShowNotification());
    }

    private IEnumerator ShowNotification()
    {
        yield return new WaitForSeconds(2.0f);
        float timer = 0;
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 endPosition = startPosition + new Vector2(0, -100);

        while (timer < animationDuration)
        {
            timer += Time.deltaTime;
            float t = animationCurve.Evaluate(timer / animationDuration);
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        timer = 0;
        while (timer < animationDuration)
        {
            timer += Time.deltaTime;
            float t = animationCurve.Evaluate(timer / animationDuration);
            rectTransform.anchoredPosition = Vector2.Lerp(endPosition, startPosition, t);
            yield return null;
        }
    }
}
