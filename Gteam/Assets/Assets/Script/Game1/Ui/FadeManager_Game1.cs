using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeManager_Game1 : MonoBehaviour
{
    public Image fadeImage;

    private void Start()
    {
        Color color = fadeImage.color;

        color.a = 0f;

        fadeImage.color = color;
        fadeImage.gameObject.SetActive(false);
    }
    public IEnumerator FadeOut(float duration)
    {
        fadeImage.gameObject.SetActive(true);

        float time = 0f;

        Color color = fadeImage.color;

        while (time < duration)
        {
            time += Time.deltaTime;

            color.a = Mathf.Lerp(
            0f,
            1f,
            time / duration
            );

            fadeImage.color = color;

            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
    }
}
