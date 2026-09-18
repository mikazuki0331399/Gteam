using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    public IEnumerator FadeOut(float duration)
    {
        float timer = 0f;

        Color color = fadeImage.color;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            color.a = timer / duration;

            fadeImage.color = color;

            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
    }
}