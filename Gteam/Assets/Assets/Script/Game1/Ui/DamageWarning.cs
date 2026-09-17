using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageWarning : MonoBehaviour
{
    public Image damageImage;

    public bool isDanger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDanger)
        {
            Color color = damageImage.color;

            color.a = Mathf.PingPong(Time.time * 0.5f, 0.1f);
            damageImage.color = color;
        }
        else
        {
            Color color = damageImage.color;

            color.a = .0f;

            damageImage.color = color;
        }
    }
}
