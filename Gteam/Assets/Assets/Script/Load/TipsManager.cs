using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI messageText;

    public TipData[] tips;

    public SlideIn slideIn1;
    public Image PickUpImage;

    void Start()
    {
        ShowRandomTip();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ShowRandomTip();
        }
    }

    void ShowRandomTip()
    {
        int index = Random.Range(0, tips.Length);

        titleText.text = tips[index].title;
        messageText.text = tips[index].message;
        

        PickUpImage.color = tips[index].titleColor;
        slideIn1.PlaySlide();
     
    }
}