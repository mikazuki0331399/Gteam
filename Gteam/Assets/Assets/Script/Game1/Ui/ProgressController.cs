using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    public RectTransform arrow;

    public float gameTime = 60f;
    public bool gameStarted = false;
    private float timer = 0f;

    public float startX = 200f;
    public float endX = 250f;
    public float fixedY = 0f;
    void Update()
    {

        if (!gameStarted)
        {
            return;
        }
        timer += Time.deltaTime;

        float progress = timer / gameTime;

        progress = Mathf.Clamp01(progress);

        float x = Mathf.Lerp(
            startX,
            endX,
            progress
        );


        arrow.anchoredPosition =
            new Vector2(
            x,
            fixedY
            );

    }
}

