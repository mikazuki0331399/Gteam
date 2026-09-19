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
        Debug.Log("FadeOut開始");

        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;

            Color color = fadeImage.color;
            color.a = time / duration;
            fadeImage.color = color;

            Debug.Log(color.a);

            yield return null;
        }

        Debug.Log("FadeOut終了");
    }
}