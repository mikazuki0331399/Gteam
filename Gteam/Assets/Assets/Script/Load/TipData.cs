using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class TipData
{
    public string title;

    [TextArea(2, 5)]
    public string message;
}