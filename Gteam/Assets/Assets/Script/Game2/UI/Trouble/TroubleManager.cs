using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroubleManager : MonoBehaviour
{
    [SerializeField]
    private PlayerPowerController playerPower;

    IEnumerator Start()
    {
        while (true)
        {
            // 10～20秒の間でランダム待機
            yield return new WaitForSeconds(
                Random.Range(10f, 20f));

            Debug.Log("姿勢乱れ発生！");

            // トラブル開始
            playerPower.isTrouble = true;

            // 10秒継続
            yield return new WaitForSeconds(10f);

            // トラブル終了
            playerPower.isTrouble = false;

            Debug.Log("姿勢乱れ終了");
        }
    }
}