using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HealMove : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 10000f;

    private Vector3 moveDirection;

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    void Update()
    {
        // ˆÚ“®
        transform.position +=
            moveDirection * speed * Time.deltaTime;

        // ‰ñ“]
        transform.Rotate(
            0,
            rotateSpeed * Time.deltaTime,
            0
        );
        if (
           transform.position.x > 45f ||
           transform.position.x < -45f ||
           transform.position.z > 70f ||
           transform.position.z < -45f
       )
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            Destroy(gameObject);
        }
    }
}
