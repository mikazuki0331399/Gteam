using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject explanationPanel;

    public static bool IsExplaining = true;

    private void Start()
    {
        IsExplaining = true;
        explanationPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            explanationPanel.SetActive(false);

            IsExplaining = false;

            enabled = false;
        }
    }
}
        