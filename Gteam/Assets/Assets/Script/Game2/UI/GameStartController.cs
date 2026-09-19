using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartController : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialPanel;

    [SerializeField]
    private PlayerPowerController playerController;

    [SerializeField]
    private TimerController timerController;

    [SerializeField]
    private TargetRangeController targetRangeController;

    [SerializeField]
    private TroubleManager troubleManager;

    [SerializeField]
    private SystemErrorManager systemErrorManager;

    private bool gameStarted = false;

    void Start()
    {
        playerController.enabled = false;
        timerController.enabled = false;
        targetRangeController.enabled = false;
        troubleManager.enabled = false;
        systemErrorManager.enabled = false;
    }

    void Update()
    {
        if (!gameStarted && Input.anyKeyDown)
        {
            gameStarted = true;

            tutorialPanel.SetActive(false);

            playerController.enabled = true;
            timerController.enabled = true;
            targetRangeController.enabled = true;
            troubleManager.enabled = true;
            systemErrorManager.enabled = true;
        }
    }
}