using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimerController : MonoBehaviour
{
    // 制限時間
    [SerializeField]
    private float timeLimit = 60f;

    // Timerのテキスト
    [SerializeField]
    private TextMeshProUGUI timerText;

    // フェード管理
    [SerializeField]
    private FadeManager fadeManager;
    private bool isGameOver = false;
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
        if (timeLimit <= 0 && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(GameOverRoutine());
        }
    }

    IEnumerator GameOverRoutine()
    {
        yield return StartCoroutine(
            fadeManager.FadeOut(1f));

        Debug.Log("ゲームオーバーシーンへ移動");
        SceneManager.LoadScene("GameOverScene");
    }
}
