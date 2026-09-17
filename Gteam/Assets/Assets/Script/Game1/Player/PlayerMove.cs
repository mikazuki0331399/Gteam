using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool canMove = false;
    // プレイヤーの移動速度
    [SerializeField]
    private float moveSpeed = 15.0f;

    // プレイヤーのHP
    [SerializeField]
    private int hp = 10;

    //プレイヤーのHPバーのやつ
    [SerializeField]
    private HealthGauge healthGauge;

    // 無敵時間の長さ
    [SerializeField]
    private float invincibleTime = 1.0f;

    // 現在無敵中か
    private bool isInvincible = false;

    // プレイヤーが移動できる範囲
    [SerializeField]
    private float minX = -8.0f;

    [SerializeField]
    private float maxX = 8.0f;

    [SerializeField]
    private float minZ = -4.0f;

    [SerializeField]
    private float maxZ = 4.0f;

    // カメラ揺れ
    [SerializeField]
    private CameraShake cameraShake;

    [SerializeField]
    private DamageWarning damageWarning;
   
    void Start()
    {
        canMove = false;
    }

    void Update()
    {
     
        if (!canMove)
        {
            return;
        }
        // 左右入力取得
        float horizontal = Input.GetAxisRaw("Horizontal");

        // 前後入力取得
        float vertical = Input.GetAxisRaw("Vertical");

        // 移動方向
        Vector3 move = new Vector3(horizontal, 0.0f, vertical);

        // プレイヤーを移動
        transform.position += move.normalized * moveSpeed * Time.deltaTime;

        // 現在の座標を取得
        Vector3 pos = transform.position;

        // X座標（左右）の移動範囲を制限
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        // Z座標（前後）の移動範囲を制限
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        // 制限後の座標を反映
        transform.position = pos;
    }

    // デブリと接触した時

    private void OnTriggerEnter(Collider other)
    {
        // デブリに当たった時
        if (other.CompareTag("Debris"))
        {
            // 無敵中ならダメージを受けない
            if (isInvincible)
            {
                return;
            }

            hp--;
            if (hp <= 3)
            {
                damageWarning.isDanger = true;
            }
            
            if (hp <= 0)
            {
                damageWarning.isDanger = false;
                FindObjectOfType<GameManager>()
                    .FinishGame();
            }

            healthGauge.SetGauge((float)hp / 10f);


            // ダメージ時だけ揺らす
            healthGauge.ShakeGauge();

            cameraShake.Shake();

            Debug.Log("被弾！");
            Debug.Log("現在HP : " + hp);

            StartCoroutine(Invincible());

            if (hp <= 0)
            {
                Debug.Log("ゲームオーバー");
            }
        }

        // 回復アイテムに当たった時
        if (other.CompareTag("Health"))
        {
            hp++;
            if (hp >= 4)
            {
                damageWarning.isDanger = false;
            }
            // HPが最大値を超えないようにする
            if (hp > 10)
            {
                hp = 10;
            }

            // HPバー更新
            healthGauge.SetGauge((float)hp / 10f);

            Debug.Log("HP回復！");
            Debug.Log("現在HP : " + hp);

            // 回復アイテムを消す
            Destroy(other.gameObject);
        }
    }


    // 無敵時間処理
    private IEnumerator Invincible()
    {
        isInvincible = true;

        Debug.Log("無敵開始");

        yield return new WaitForSeconds(invincibleTime);

        isInvincible = false;

        Debug.Log("無敵終了");
    }
}