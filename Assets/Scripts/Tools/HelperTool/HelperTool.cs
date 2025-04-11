using System;
using System.Collections;
using TMPro;
using UnityEngine;

public static class HelperTool
{
 
    public static IEnumerator MakeLerp(float startValue, float targetValue, float lerpTime,
    Action<float> updateX, Action<float> updateY = null, Action<float> updateZ = null)
    {
        float elapsedTime = 0f;
        while (elapsedTime < lerpTime)
        {
            float t = elapsedTime / lerpTime;
            float currentValue = Mathf.Lerp(startValue, targetValue, t);

            updateX?.Invoke(currentValue);
            updateY?.Invoke(currentValue);
            updateZ?.Invoke(currentValue);

            elapsedTime += Time.deltaTime;
            yield return null; // �ȴ���һ֡
        }
        updateX?.Invoke(targetValue);
        updateY?.Invoke(targetValue);
        updateZ?.Invoke(targetValue);
    }
    public static IEnumerator MakeLerp(Vector3 startPosition, Vector3 direction, float lerpTime,
    Action<Vector3> updatePosition)
    {
        Vector3 targetPosition = startPosition + direction.normalized * (direction.magnitude);
        float elapsedTime = 0f;

        while (elapsedTime < lerpTime)
        {
            float t = elapsedTime / lerpTime;
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, t);

            updatePosition?.Invoke(currentPosition);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        updatePosition?.Invoke(targetPosition);
    }



   
}




