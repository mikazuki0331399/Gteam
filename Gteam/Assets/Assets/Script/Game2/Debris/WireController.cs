using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour
{
    [SerializeField]
    private Transform satellite;

    [SerializeField]
    private Transform debris;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        line.SetPosition(0, satellite.position);
        line.SetPosition(1, debris.position);
    }
}