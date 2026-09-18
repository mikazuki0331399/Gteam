using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HealMove : MonoBehaviour
{
    public float speed = 5f;

    public float lifeTime = 15f;

    public float rotateSpeed = 180f;
    

    private Vector3 moveDirection;

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    void Start()
    {
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

    void Update()
    {
        transform.position +=
        moveDirection * speed * Time.deltaTime;

        transform.Rotate(
        0,
        rotateSpeed * Time.deltaTime,
        0
        );
    }
}