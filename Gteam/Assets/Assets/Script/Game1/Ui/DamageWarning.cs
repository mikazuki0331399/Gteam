using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageWarning : MonoBehaviour
{
    public Image damageImage;

    public bool isDanger = false;

    public float blinkSpeed = 2f;

    public float maxAlpha = 0.3f;

    void Update()
    {
        Debug.Log(isDanger);

        Color color = damageImage.color;
        color.a = 1f;
        damageImage.color = color;

        if (isDanger)
        {
            color.a =
            Mathf.PingPong(
            Time.time * blinkSpeed,
            maxAlpha
            );
        }
        else
        {
            color.a = 0f;
        }

        damageImage.color = color;
    }
}