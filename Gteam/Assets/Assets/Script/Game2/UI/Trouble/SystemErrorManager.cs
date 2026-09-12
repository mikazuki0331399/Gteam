using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    IEnumerator Start()
    {
        while (true)
        {
            // エラー発生まで待機
            yield return new WaitForSeconds(
                Random.Range(20f, 30f));

            Debug.Log("SYSTEM ERROR 発生");

            // ノイズ表示
            noiseImage1.SetActive(true);
            noiseImage2.SetActive(true);

            systemErrorText.SetActive(true);

            float errorTime = 10f;
            float timer = 0f;

            while (timer < errorTime)
            {
                targetRange.SetActive(!targetRange.activeSelf);

                yield return new WaitForSeconds(0.5f);

                timer += 0.5f;
            }

            // 終了時は必ず表示状態に戻す
            targetRange.SetActive(true);

            // ノイズ非表示
            noiseImage1.SetActive(false);
            noiseImage2.SetActive(false);

            systemErrorText.SetActive(false);

            Debug.Log("SYSTEM ERROR 終了");
        }
    }
}