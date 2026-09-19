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
        if (isDanger)
        {
            Debug.Log(gameObject.name + " が赤表示中");
        }

        Color color = damageImage.color;
        if (isDanger)
        {
            color.a = 0.5f;
        }
        else
        {
            color.a = 0f;
        }

        damageImage.color = color;
    }
}