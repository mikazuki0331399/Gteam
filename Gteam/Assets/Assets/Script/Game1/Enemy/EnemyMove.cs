using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 10000f;

    // 生存時間
    public float lifeTime = 15f;

    private Vector3 moveDirection;

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    private void Start()
    {
        // 一定時間後に消す
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position +=
            moveDirection * speed * Time.deltaTime;

        transform.Rotate(
            0,
            rotateSpeed * Time.deltaTime,
            0
        );

        // 遠くへ行ったら消す
        if (
            transform.position.x > 1000f ||
            transform.position.x < -1000f ||
            transform.position.z > 1000f ||
            transform.position.z < -1000f
        )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 回復アイテムは無視
        if (CompareTag("Health"))
        {
            return;
        }

        // プレイヤーに当たった
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            return;
        }

        EnemyMove enemy =
        other.GetComponent<EnemyMove>();

        if (enemy != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
   
}