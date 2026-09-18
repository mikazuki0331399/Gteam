using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRange = 15f;
    public float destroyOffset = 20f;
    public GameObject[] enemyPrefabs;

    public Transform leftSpawn;
    public Transform rightSpawn;
    public Transform leftUpSpawn;
    public Transform rightUpSpawn;
    public float randomSpawnRange = 5f;

    public bool gameStarted = false;
    public GameObject enemyPrefab;
    public Transform centerPoint;
    public void StartGame()
    {
        gameStarted = true;
        InvokeRepeating(
            nameof(SpawnEnemy),
            1f,
            0.5f
        );
    }

    public void StopGame()
    {
        CancelInvoke();
    }
    void SpawnEnemy()
    {
        Transform[] points =
        {
        leftSpawn,
        rightSpawn,
        leftUpSpawn,
        rightUpSpawn
    };

        Transform spawnPoint =
            points[Random.Range(0, points.Length)];

        Vector3 direction =
            (
            centerPoint.position -
            spawnPoint.position
            ).normalized;
        
        if (spawnPoint == leftSpawn)
            direction = new Vector3(1, 0, -0.5f);

        else if (spawnPoint == rightSpawn)
            direction = new Vector3(-1, 0, -0.5f);

        else if (spawnPoint == leftUpSpawn)
            direction = new Vector3(1, 0, -1);

        else
            direction = new Vector3(-1, 0, -1);

        GameObject enemy =
            Instantiate(
                enemyPrefab,
                spawnPoint.position,
                Quaternion.identity
            );

        enemy.GetComponent<EnemyMove>()
            .SetDirection(direction);
    }

   
    private void OnDrawGizmos()
    {
        if (leftSpawn != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(
                leftSpawn.position,
                0.5f
            );
        }

        if (rightSpawn != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(
                rightSpawn.position,
                0.5f
            );
        }
    }
}

