using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRangeController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 150f;

    [SerializeField]
    private float minY = -300f;

    [SerializeField]
    private float maxY = 300f;

    // 次に向かう目標地点
    private float targetY;

    void Start()
    {
        SetNewTarget();
    }

    void Update()
    {
        Vector3 pos = transform.localPosition;

        // 目標地点へ移動
        pos.y = Mathf.MoveTowards(
            pos.y,
            targetY,
            moveSpeed * Time.deltaTime);

        transform.localPosition = pos;

        // 目標地点に到着したら次の目標を決める
        if (Mathf.Abs(pos.y - targetY) < 5f)
        {
            SetNewTarget();
        }
    }

    void SetNewTarget()
    {
        targetY = Random.Range(minY, maxY);
    }
}