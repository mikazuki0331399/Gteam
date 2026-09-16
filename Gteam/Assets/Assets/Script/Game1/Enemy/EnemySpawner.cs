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
        int rand = Random.Range(0, 4);

        Transform spawnPoint = null;
        Vector3 direction = Vector3.zero;

        switch (rand)
        {
            case 0:
                spawnPoint = leftSpawn;
                direction = new Vector3(1, 0, -0.5f);
                break;

            case 1:
                spawnPoint = rightSpawn;
                direction = new Vector3(-1, 0, -0.5f);
                break;
            case 2:
                spawnPoint = leftUpSpawn;
                direction = new Vector3(1, 0, -1);
                break;
            case 3:
                spawnPoint = rightUpSpawn;
                direction = new Vector3(-1, 0, -1);
                break;
        }
        float limitZ = 46.3f + spawnRange + destroyOffset;

        int enemyType =
            Random.Range(0, enemyPrefabs.Length);


        Vector3 spawnPos = spawnPoint.position;

        spawnPos.z += Random.Range(
            0f,
            spawnRange
        );



        GameObject enemy =
            Instantiate(
                enemyPrefabs[enemyType],
                spawnPos,
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

