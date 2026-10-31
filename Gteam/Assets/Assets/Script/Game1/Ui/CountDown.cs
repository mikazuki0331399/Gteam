using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public TextMeshProUGUI countdownText;
    public GameManager gameManager;
    public EnemySpawner enemySpawner;
    public ProgressController progressController;
    public PlayerMove playerMove;
    public StarMove[] stars;
    public HealSpawner healSpawner;
    IEnumerator Start()
    {
        while (ExplanationManager.IsExplaining)
        {
            yield return null;
        }

        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        countdownText.text = "START!";
        yield return new WaitForSeconds(1);

        countdownText.gameObject.SetActive(false);

        playerMove.canMove = true;

        foreach (StarMove star in stars)
        {
            star.canMove = true;
        }

        enemySpawner.StartGame();
        healSpawner.StartGame();
        gameManager.gameStarted = true;
        progressController.gameStarted = true;
    }

}
