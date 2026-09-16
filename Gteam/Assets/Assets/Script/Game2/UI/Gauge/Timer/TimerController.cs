using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    // 制限時間
    [SerializeField]
    private float timeLimit = 60f;

    // Timerのテキスト
    [SerializeField]
    private TextMeshProUGUI timerText;

    void Update()
    {
        // 時間を減らす
        timeLimit -= Time.deltaTime;

        // 0以下にならないようにする
        if (timeLimit < 0)
        {
            timeLimit = 0;
        }

        // 表示更新
        timerText.text = "TIME : " + Mathf.CeilToInt(timeLimit);

        // ゲームオーバー
        if (timeLimit <= 0)
        {
            Debug.Log("ゲームオーバー");
        }
    }
}
