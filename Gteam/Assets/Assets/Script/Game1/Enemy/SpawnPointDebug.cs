using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnPointDebug : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    public float lineLength = 3f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(transform.position, 0.3f);

        Gizmos.DrawLine(
            transform.position,
            transform.position + direction.normalized * lineLength
        );
    }
}
