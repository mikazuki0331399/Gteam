using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private float minX = -108.0f;

    [SerializeField]
    private float maxX = 106.0f;

    [SerializeField]
    private float minZ = -50.0f;

    [SerializeField]
    private float maxZ = 50.0f;

    // カメラ揺れ
    [SerializeField]
    private CameraShake cameraShake;

    [SerializeField]
    private DamageWarning damageWarning;

    // 加速度
    [SerializeField]
    private float acceleration = 120f;

    // 最大速度
    [SerializeField]
    private float maxSpeed = 50f;

    // 現在の速度
    private Vector3 velocity;

    // 音再生
    [SerializeField]
    private AudioSource audioSource;

    // 被弾音
    [SerializeField]
    private AudioClip damageSE;

    // 回復音
    [SerializeField]
    private AudioClip healSE;


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

        Vector3 input = new Vector3(horizontal, 0.0f, vertical);

        // 加速度を与える
        velocity += input.normalized *
                    acceleration *
                    Time.deltaTime;

        // 最大速度制限
        velocity = Vector3.ClampMagnitude(
                        velocity,
                        maxSpeed);

        // 少しずつ減速
        //velocity *= 0.98f;

        // 速度で移動
        transform.position +=
            velocity * Time.deltaTime;

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

            audioSource.PlayOneShot(damageSE);

            if (hp <= 3)
            {
                Debug.Log("Danger ON");

                damageWarning.isDanger = true;
            }


            
            if (hp <= 0)
            {
                damageWarning.isDanger = false;
                FindObjectOfType<GameManager>()
                    .FinishGame();
                SceneManager.LoadScene("GameOverScene");
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

            audioSource.PlayOneShot(healSE);

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