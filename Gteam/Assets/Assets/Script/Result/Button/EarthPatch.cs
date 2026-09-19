using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPatch : MonoBehaviour
{
    [SerializeField] private float rotationPeriod = 60.0f;
    [SerializeField] private bool reverse = false;

    private void Update()
    {
        float direction = reverse ? -1.0f : 1.0f;
        float angle = (360.0f / rotationPeriod) * Time.deltaTime * direction;

        transform.Rotate(Vector3.up, angle, Space.Self);
    }
}