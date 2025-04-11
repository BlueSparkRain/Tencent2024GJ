using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class UITween : MonoSingleton<UITween>
{

    private AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    /// <summary>
    /// UIԪ�ص�Move�����߼�
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="startPos"></param>
    /// <param name="targgetPos"></param>
    /// <param name="transDuration"></param>
    public void UIDoMove(Transform transform, Vector2 startPos, Vector2 targgetPos, float transDuration)
    {
        transform.gameObject.SetActive(false);

        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        //���ÿ�ʼλ��
        rectTransform.anchoredPosition = startPos;
        transform.gameObject.SetActive(true);

        //lerp����λ�û���
        StartCoroutine(UIDoMove(rectTransform, startPos, targgetPos, transDuration));
    }

    public void UIDoFade(Transform transform, float startValue, float endValue, float duration)
    {
        CanvasGroup canvasGroup = transform.GetComponent<CanvasGroup>();
        canvasGroup.alpha = startValue;
        StartCoroutine(UIDoFade(canvasGroup, startValue, endValue, duration));
    }

    IEnumerator UIDoFade(CanvasGroup canvasGroup, float startValue, float endValue, float duration)
    {
        float timer = 0;
        while (timer <= duration)
        {
            timer += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(startValue, endValue, curve.Evaluate(timer / duration));
            yield return null;
        }
    }

    /// <summary>
    ///  UIԪ�ص�LocalMove�����߼�
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="targgetPos"></param>
    /// <param name="transDuration"></param>
    public void UIDoLocalMove(Transform transform, Vector3 direction, float transDuration)
    {
        transform.gameObject.SetActive(false);
        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        Vector3 startPos = rectTransform.anchoredPosition;
        Vector3 targetPos = startPos + direction;
        transform.gameObject.SetActive(true);
        StartCoroutine(UIDoMove(rectTransform, startPos, targetPos, transDuration));
    }

    IEnumerator UIDoMove(RectTransform rectTransform, Vector2 startPos, Vector2 targetPos, float transDuration)
    {
        float timer = 0;
        while (timer <= transDuration)
        {
            timer += Time.unscaledDeltaTime;
            rectTransform.anchoredPosition = Vector3.Slerp(startPos, targetPos, curve.Evaluate(timer / transDuration));
            yield return null;
        }
    }
}
