using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerController : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 600f;

    [SerializeField]
    private float maxSpeed = 100f;

    //乱れ中
    [SerializeField]
    private float troubleMaxSpeed = 50f;

    [SerializeField]
    private float minY = -330f;

    [SerializeField]
    private float maxY = 330f;

    //乱れ中
    [SerializeField]
    private float troubleAcceleration = 300f;

    // トラブル中かどうか
    public bool isTrouble = false;

    // 現在の速度
    private float velocity;

    void Update()
    {
        float input = Input.GetAxisRaw("Vertical");

        //最大速度
        float currentMaxSpeed = maxSpeed;

        if (isTrouble)
        {
            currentMaxSpeed = troubleMaxSpeed;
        }

        // 加速度
        float currentAcceleration = acceleration;

        if (isTrouble)
        {
            currentAcceleration = troubleAcceleration;
        }

        velocity += input * currentAcceleration * Time.deltaTime;


        if (isTrouble)
        {
            currentMaxSpeed = troubleMaxSpeed;
        }

        velocity = Mathf.Clamp(
            velocity,
            -currentMaxSpeed,
            currentMaxSpeed);

        // 姿勢乱れ中は勝手に流される
        if (isTrouble)
        {
            velocity += Random.Range(-10000f, 10000f) * Time.deltaTime;
        }

        Vector3 pos = transform.localPosition;

        // 速度で移動
        pos.y += velocity * Time.deltaTime;

        // 範囲制限
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.localPosition = pos;
    }
}