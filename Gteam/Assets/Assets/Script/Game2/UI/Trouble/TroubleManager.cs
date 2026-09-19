using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TroubleManager : MonoBehaviour
{
    [SerializeField]
    private PlayerPowerController playerPower;

    [SerializeField]
    private TextMeshProUGUI troubleText;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip cautionSE;

    [SerializeField]
    private AudioClip troubleSE;
    IEnumerator Start()
    {
        while (true)
        {

            // 10～20秒の間でランダム待機
            yield return new WaitForSeconds(
                Random.Range(10f, 20f));

            Debug.Log("姿勢乱れ発生！");

            // CAUTION
            troubleText.text = "CAUTION";

            troubleText.gameObject.SetActive(true);

            audioSource.PlayOneShot(cautionSE);

            yield return new WaitForSeconds(1f);

            troubleText.color = Color.white;

            // 内容表示
            troubleText.text =
                "操作が不安定になっている！";

            yield return new WaitForSeconds(3f);

            troubleText.gameObject.SetActive(false);

            // ここで姿勢乱れ開始
            playerPower.isTrouble = true;

            float troubleTime = 10f;
            float timer = 0f;

            while (timer < troubleTime)
            {
                audioSource.PlayOneShot(troubleSE);

                yield return new WaitForSeconds(2f);

                timer += 2f;
            }
            //終了
            playerPower.isTrouble = false;

            troubleText.color = Color.yellow;

            Debug.Log("姿勢乱れ終了");
        }
    }
}