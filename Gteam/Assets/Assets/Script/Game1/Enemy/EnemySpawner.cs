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
        Instantiate(
            enemyPrefab,
            transform.position,
            Quaternion.identity
  
  );

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

