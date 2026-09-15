using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCheck : MonoBehaviour
{
    // プレイヤーのバー
    [SerializeField]
    private RectTransform playerPower;

    // 成功範囲
    [SerializeField]
    private RectTransform targetRange;

    [SerializeField]
    private float progress = 0f;

    [SerializeField]
    private ProgressGaugeController progressGauge;

    void Update()
    {
        // Y座標の差を取得
        float distance =
            Mathf.Abs(
                playerPower.localPosition.y -
                targetRange.localPosition.y);

        // 成功範囲判定
        if (distance < 40f)
        {
            //上昇量
            progress += 1f * Time.deltaTime;

            //Debug.Log("進行度 : " + progress);
        }

        if (distance < 40f)
        {
            progress += 10f * Time.deltaTime;

            progressGauge.SetProgress(progress);

            //Debug.Log("進行度 : " + progress);
        }

        //ゴール処理
        if (progress >= 100f)
        {
            Debug.Log("ゲームクリア！");
        }
    }
}
