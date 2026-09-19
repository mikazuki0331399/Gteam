using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearFont : MonoBehaviour
{
    public TextMeshProUGUI text;

    public float speed = 50.0f;

    private float alpha = 0.0f;

    void Start()
    {
        alpha = 0.0f;
        SetAlpha();
    }

    void Update()
    {
        if (alpha < 255.0f)
        {
            alpha += speed * Time.deltaTime;

            if (alpha > 255.0f)
            {
                alpha = 255.0f;
            }

            SetAlpha();
        }
    }

    void SetAlpha()
    {
        Color color = text.color;

        color.a = alpha / 255.0f;

        text.color = color;
    }
}
