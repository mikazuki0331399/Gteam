using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spin : MonoBehaviour
{
    public Transform[] spheres;

    public float radius = 0.5f;
    public float speed = 180f;

    private Vector3 center;

    private void Start()
    {
        center = transform.position;
    }

    void Update()
    {
        for (int i = 0; i < spheres.Length; i++)
        {
            float angle =
            Time.time * speed + i * (360f/spheres.Length);

            float rad = angle * Mathf.Deg2Rad;

            float x = Mathf.Cos(rad) * radius;
            float y = Mathf.Sin(rad) * radius;

            spheres[i].position =
            center + new Vector3(x, y, 0);
        }
    }
}
