using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverCollar : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    // 色が変化する速さ
    [SerializeField] private float speed = 0.2f;

    // 0～1の移動量
    private float t = 0.0f;

    void Update()
    {
        // すでに赤なら固定
        if (t >= 1.0f)
        {
            return;
        }

        // ゆっくり移動
        t += Time.deltaTime * speed;

        // 0～1に制限
        t = Mathf.Clamp01(t);

        // パレット上の座標
        float saturation = t;
        float brightness = t;

        // HSV → RGB
        Color color = Color.HSVToRGB(
            0.0f,          // Hue：赤
            saturation,   // 彩度
            brightness    // 明度
        );

        // 文字の色を変更
        text.color = color;
    }
}
