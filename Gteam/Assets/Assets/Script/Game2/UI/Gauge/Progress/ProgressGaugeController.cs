using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressGaugeController : MonoBehaviour
{
    [SerializeField]
    private Image fillImage;

    public void SetProgress(float progress)
    {
        fillImage.fillAmount = progress / 100f;
    }
}