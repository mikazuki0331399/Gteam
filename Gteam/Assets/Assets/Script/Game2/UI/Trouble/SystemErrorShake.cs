using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemErrorShake : MonoBehaviour
{
    [SerializeField]
    private float shakePower = 0.05f;

    public bool isSystemError = false;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (isSystemError)
        {
            float x = Random.Range(-shakePower, shakePower);
            float z = Random.Range(-shakePower, shakePower);

            transform.position = startPos + new Vector3(x, 0, z);
        }
        else
        {
            transform.position = startPos;
        }
    }
}