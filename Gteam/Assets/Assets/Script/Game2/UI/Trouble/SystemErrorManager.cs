using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SystemErrorManager : MonoBehaviour
{
    [SerializeField]
    private GameObject targetRange;

    [SerializeField]
    private GameObject noiseImage1;

    [SerializeField]
    private GameObject noiseImage2;

    [SerializeField]
    private GameObject systemErrorText;

    [SerializeField]
    private TextMeshProUGUI troubleText;

    [SerializeField]
    private SystemErrorShake systemErrorShake;


    IEnumerator Start()
    {
        while (true)
        {
            // エラー発生まで待機
            yield return new WaitForSeconds(
                Random.Range(20f, 30f));

            Debug.Log("SYSTEM ERROR 発生");

            systemErrorShake.isSystemError = true;

            troubleText.text = "CAUTION";

            troubleText.gameObject.SetActive(true);

            yield return new WaitForSeconds(2f);

            troubleText.gameObject.SetActive(false);

            // ノイズ表示
            noiseImage1.SetActive(true);
            noiseImage2.SetActive(true);

            systemErrorText.SetActive(true);

            float errorTime = 10f;
            float timer = 0f;

            while (timer < errorTime)
            {
                targetRange.SetActive(!targetRange.activeSelf);

                systemErrorText.SetActive(
                    !systemErrorText.activeSelf);

                yield return new WaitForSeconds(0.5f);

                timer += 0.5f;
            }

            // 終了時は必ず表示状態に戻す
            targetRange.SetActive(true);

            // ノイズ非表示
            noiseImage1.SetActive(false);
            noiseImage2.SetActive(false);

            systemErrorShake.isSystemError = false;

            systemErrorText.SetActive(false);

            Debug.Log("SYSTEM ERROR 終了");
        }
    }
    public void ForceStop()
    {
        targetRange.SetActive(true);

        noiseImage1.SetActive(false);
        noiseImage2.SetActive(false);

        systemErrorText.SetActive(false);
    }
}