using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisMove : MonoBehaviour
{
    // 開始位置
    private Vector3 startPos;

    // 終了位置
    [SerializeField]
    private Transform targetPoint;

    void Start()
    {
        startPos = transform.position;
    }

    public void UpdateProgress(float progress)
    {
        transform.position = Vector3.Lerp(
            startPos,
            targetPoint.position,
            progress / 100f);
    }
}