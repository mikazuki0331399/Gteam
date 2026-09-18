using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.TestTools;

public class EnemySpawner : MonoBehaviour
{
    [Header("敵プレハブ")]
    public GameObject[] enemyPrefabs;

    [Header("スポーン地点")]
    public Transform leftSpawn;
    public Transform rightSpawn;
    public Transform leftUpSpawn;
    public Transform rightUpSpawn;

    [Header("スポーン設定")]
    public float spawnInterval = 0.5f;

    [Header("スポーン制御")]
    public float moveRange = 10f;
    public float moveSpeed = 10f;

    private Vector3 startPos;

    public void StartGame()
    {
        startPos = transform.position;

        InvokeRepeating(
            nameof(SpawnEnemy),
            1f,
            spawnInterval
        );
    }

    public void StopGame()
    {
        CancelInvoke();
    }

    private void SpawnEnemy()
    {
        Transform[] spawnPoints =
        {
            leftSpawn,
            rightSpawn,
            leftUpSpawn,
            rightUpSpawn
        };

        Transform spawnPoint =
        spawnPoints[
        Random.Range(
        0,
        spawnPoints.Length
        )
        ];

        GameObject enemyPrefab =
        enemyPrefabs[
        Random.Range(
        0,
        enemyPrefabs.Length
        )
        ];

        Vector3 direction;

        if (spawnPoint == leftSpawn)
        {
            direction = new Vector3(1, 0, 0f);
        }
        else if (spawnPoint == rightSpawn)
        {
            direction = new Vector3(-1, 0, 0f);
        }
        else if (spawnPoint == leftUpSpawn)
        {
            direction = new Vector3(1, 0, -1);
        }
        else
        {
            direction = new Vector3(-1, 0, -1);
        }

        // Z方向をランダムにずらす
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.z += Random.Range(
        0f,
        25f
        );

        GameObject enemy =
        Instantiate(
        enemyPrefab,
        spawnPos,
        Quaternion.identity
        );

        enemy.GetComponent<EnemyMove>()
        .SetDirection(direction);
    }
    private void Update()
    {
        float z =
        Mathf.Sin(Time.time * moveSpeed)
        * moveRange;

        transform.position =
        startPos + new Vector3(0, 0, z);
    }
}