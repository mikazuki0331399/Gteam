using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.5f;

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}