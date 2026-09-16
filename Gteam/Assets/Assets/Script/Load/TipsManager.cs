using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TipsManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI messageText;

    public TipData[] tips;

    private bool isAnimating;
    void Start()
    {
        ShowRandomTip();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isAnimating)
        {
            StartCoroutine(ChangeTip());
        }
    }

    IEnumerator ChangeTip()
    {
        isAnimating = true;

        Vector2 titleStart = titleText.rectTransform.anchoredPosition;
        Vector2 msgStart = messageText.rectTransform.anchoredPosition;

        CanvasGroup titleGroup =
            titleText.GetComponent<CanvasGroup>();

        CanvasGroup msgGroup =
            messageText.GetComponent<CanvasGroup>();

        // è„Ç÷è¡Ç¶ÇÈ
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 3f;

            titleText.rectTransform.anchoredPosition =
                Vector2.Lerp(
                    titleStart,
                    titleStart + Vector2.up * 50f,
                    t);

            messageText.rectTransform.anchoredPosition =
                Vector2.Lerp(
                    msgStart,
                    msgStart + Vector2.up * 50f,
                    t);

            titleGroup.alpha = 1f - t;
            msgGroup.alpha = 1f - t;

            yield return null;
        }

        int index = Random.Range(0, tips.Length);

        titleText.text = tips[index].title;
        messageText.text = tips[index].message;

        // â∫Ç…îzíu
        titleText.rectTransform.anchoredPosition =
            titleStart - Vector2.up * 50f;

        messageText.rectTransform.anchoredPosition =
            msgStart - Vector2.up * 50f;

        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 3f;

            titleText.rectTransform.anchoredPosition =
                Vector2.Lerp(
                    titleStart - Vector2.up * 50f,
                    titleStart,
                    t);

            messageText.rectTransform.anchoredPosition =
                Vector2.Lerp(
                    msgStart - Vector2.up * 50f,
                    msgStart,
                    t);

            titleGroup.alpha = t;
            msgGroup.alpha = t;

            yield return null;
        }

        isAnimating = false;
    }
    void ShowRandomTip()
    {
        int index = Random.Range(0, tips.Length);

        titleText.text = tips[index].title;
        messageText.text = tips[index].message;
    }
}
