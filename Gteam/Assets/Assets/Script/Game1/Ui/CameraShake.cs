using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    // —h‚ê‚é‹­‚³
    [SerializeField]
    private float shakePower = 0.2f;

    // —h‚ê‚éŽžŠÔ
    [SerializeField]
    private float shakeTime = 0.2f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float timer = 0f;

        while (timer < shakeTime)
        {
            float x = Random.Range(-shakePower, shakePower);
            float y = Random.Range(-shakePower, shakePower);
            float z = Random.Range(-shakePower, shakePower);
            //‚Ç‚ÌÀ•W‚ð—h‚ç‚·‚©
            transform.position = startPos + new Vector3(x, 0, z);

            timer += Time.deltaTime;

            yield return null;
        }

        transform.position = startPos;
    }
}