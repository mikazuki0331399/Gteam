using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameObject clearText;

    [SerializeField]
    private PlayerPowerController playerController;

    [SerializeField]
    private TimerController timerController;

    [SerializeField]
    private TargetRangeController targetRangeController;

    [SerializeField]
    private TroubleManager troubleManager;

    [SerializeField]
    private SystemErrorManager systemErrorManager;

    [SerializeField]
    private FadeManager fadeManager;

    private bool isClear = false;

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
            progress += 1f * Time.deltaTime;

            progressGauge.SetProgress(progress);

            debrisMove.UpdateProgress(progress);

            Debug.Log("進行度 : " + progress);
        }

        //ゴール処理
        if (progress >= 100f && !isClear)
        {
            isClear = true;
            StartCoroutine(ClearRoutine());
        }
    }

    IEnumerator ClearRoutine()
    {
        // プレイヤー操作停止
        playerController.enabled = false;
        timerController.enabled = false;
        targetRangeController.enabled = false;

        troubleManager.StopAllCoroutines();
        systemErrorManager.StopAllCoroutines();

        troubleManager.enabled = false;
        systemErrorManager.enabled = false;

        // システムエラー強制終了
        systemErrorManager.ForceStop();

        // クリア文字表示
        clearText.SetActive(true);

        Debug.Log("MISSION COMPLETE");

        // 3秒待つ
        yield return new WaitForSeconds(3f);

        // フェードアウト
        //yield return StartCoroutine(fadeManager.FadeOut(1f));

        Debug.Log("クリアシーンへ移動");

        // クリアシーンへ
        //SceneManager.LoadScene("ResultScene");
    }
}
