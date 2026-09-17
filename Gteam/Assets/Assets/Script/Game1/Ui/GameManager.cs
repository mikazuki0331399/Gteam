using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI finishText;

    public PlayerMove playerMove;

    public float gameTime = 60f;

    public EnemySpawner enemySpawner;

    private float timer = 0f;

    private bool isFinished = false;
    public  bool gameStarted = false;

    private void Start()
    {
        finishText.gameObject.SetActive(false);

    }
    void Update()
    {
        if(!gameStarted)
        {
                      return;
        }
        if (isFinished) return;

        timer += Time.deltaTime;
        Debug.Log("Timer = " + timer);
        if (timer >= gameTime)
        {
            Debug.Log("FINISHèåèíBê¨");
            FinishGame();
        }
    }

    public void FinishGame()
    {
        finishText.text = "FINISH!";
        finishText.gameObject.SetActive(true);
        FinishGame(finishText);
        StartCoroutine(GoResult());
    }

    public void FinishGame(TextMeshProUGUI finishUIText)
    {
        if (isFinished) return;

        isFinished = true;
        finishText.text = "FINISH!";
        finishUIText.gameObject.SetActive(true);

        playerMove.canMove = false;
        GameObject[] debris = GameObject.FindGameObjectsWithTag("Debris");
        foreach (GameObject d in debris)
        {
            Destroy(d);
        }
        GameObject[] heals = GameObject.FindGameObjectsWithTag("Health");
        foreach (GameObject h in heals)
        {
            Destroy(h);
        }
        enemySpawner.StopGame();
        Time.timeScale = 0f;
    }

    private IEnumerator GoResult()
    {
        yield return new WaitForSecondsRealtime (3f);

        SceneManager.LoadScene("ResultScene");
    }
}
