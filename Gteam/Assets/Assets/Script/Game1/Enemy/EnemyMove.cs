using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float rotateSpeed = 10000f;
    

    public float destroyDistance = 50f;
    public float speed;
    public Transform centerPoint; 

    private Vector3 startPosition;
    private Vector3 moveDirection;

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    void Start()
    {
        startPosition = transform.position;
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
        if (
            transform.position.x >  45f ||
            transform.position.x < -45f ||
            transform.position.z >  70f ||
            transform.position.z < -45f
        )
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (CompareTag("Health"))
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Debris"))
        {
            transform.localScale *= 1.5f;

            Destroy(other.gameObject);
            Destroy(gameObject, 0.25f);
        }
    }
}