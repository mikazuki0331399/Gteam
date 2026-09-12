using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;

    // カウントダウン後に動かす用
    public bool canMove = true;

    void Update()
    {
        if (!canMove)
        {
            return;
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.localPosition.y < -600f)
        {
            Vector3 pos = transform.localPosition;

            pos.y = 600f;
            pos.x = Random.Range(-900f, 900f);

            transform.localPosition = pos;
        }
    }
}