using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFloat : MonoBehaviour
{
    private Vector3 startRot;

    [SerializeField]
    private float rotateRange = 1.5f;

    [SerializeField]
    private float rotateSpeed = 0.5f;

    void Start()
    {
        startRot = transform.eulerAngles;
    }

    void Update()
    {
        Vector3 rot = startRot;

        rot.z += Mathf.Sin(Time.time * rotateSpeed) * rotateRange;

        transform.eulerAngles = rot;
    }
}