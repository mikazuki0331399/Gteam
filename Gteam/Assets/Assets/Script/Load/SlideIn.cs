using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIn : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;

    public float speed = 5f;

    private bool isMoving;

    public void PlaySlide()
    {
        transform.localPosition = startPos;
        isMoving = true;
    }

    void Update()
    {
        if (!isMoving) return;

        transform.localPosition =
            Vector3.Lerp(
                transform.localPosition,
                endPos,
                speed * Time.deltaTime);

        if (Vector3.Distance(
            transform.localPosition,
            endPos) < 1f)
        {
            transform.localPosition = endPos;
            isMoving = false;
        }
    }
}