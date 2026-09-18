using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    public GameObject[] healPrefab;

    public Transform leftSpawn;
    public Transform rightSpawn;
    public Transform leftUpSpawn;
    public Transform rightUpSpawn;

    public float spawnInterval = 7f;

    public float randomSpawnRange = 25f;

    public void StartGame()
    {
        InvokeRepeating(
            nameof(SpawnHeal),
            5f,
            spawnInterval
        );
    }

    public void StopGame()
    {
        CancelInvoke();
    }

    private void SpawnHeal()
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

        Vector3 spawnPos = spawnPoint.position;

        spawnPos.z += Random.Range(
            0f,
            25f
        );

        // èCê≥: healPrefab Ç©ÇÁÉâÉìÉ_ÉÄÇ…1Ç¬ëIë
        GameObject prefab = healPrefab[Random.Range(0, healPrefab.Length)];

        GameObject heal =
            Instantiate(
                prefab,
                spawnPos,
                Quaternion.identity
            );

        heal.GetComponent<HealMove>()
            .SetDirection(direction);
        spawnPos.z += Random.Range(
         0f,
        randomSpawnRange
            );
    }
}