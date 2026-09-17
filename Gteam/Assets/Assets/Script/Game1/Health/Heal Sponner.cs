using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    public GameObject healPrefab;

    public Transform leftSpawn;
    public Transform rightSpawn;
    public Transform leftUpSpawn;
    public Transform rightUpSpawn;

    public float spawnRange = 25f;

    void Start()
    {
        InvokeRepeating(
            nameof(SpawnHeal),
            7f,
            7f
        );
    }

    void SpawnHeal()
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

        Vector3 spawnPos = spawnPoint.position;

        spawnPos.z += Random.Range(
            0f,
            spawnRange
        );

        GameObject heal =
            Instantiate(
                healPrefab,
                spawnPos,
                Quaternion.identity
            );


        heal.GetComponent<HealMove>()
            .SetDirection(
                GetDirection(spawnPoint)
            );

    }

    Vector3 GetDirection(Transform spawnPoint)
    {
        if (spawnPoint == leftSpawn)
            return new Vector3( 1, 0, -0.5f);

        if (spawnPoint == rightSpawn)
            return new Vector3(-1, 0, -0.5f);
        if (spawnPoint == leftUpSpawn)
            return new Vector3(1, 0, -1);
     
            return new Vector3(-1, 0, -1);
    }
    void Update()
    {
        transform.Rotate(
            0,
            100 * Time.deltaTime,
            0
        );
    }
    
}
