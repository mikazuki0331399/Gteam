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

    [SerializeField]
    private DebrisMove debrisMove;

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
            //進行度
            progress += 5f * Time.deltaTime;

            progressGauge.SetProgress(progress);

            debrisMove.UpdateProgress(progress);

            Debug.Log("進行度 : " + progress);
        }

        //ゴール処理
        if (progress >= 100f)
        {
            Debug.Log("ゲームクリア！");
        }
    }
}
