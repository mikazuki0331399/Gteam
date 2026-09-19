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
    private bool isLoading;
    private bool isFinished = false;
    public  bool gameStarted = false;
    public FadeManager fadeManager;
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
       
        if (timer >= gameTime)
        {
            Debug.Log("FINISH条件達成");
            FinishGame();
        }
    }

    public void FinishGame()
    {
        finishText.text = "FINISH!";
        finishText.gameObject.SetActive(true);

        FinishGame(finishText);

        StarMove[] stars =
        FindObjectsOfType<StarMove>();

        foreach (StarMove star in stars)
        {
            star.canMove = false;
        }
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
       
        StartCoroutine(ClearRoutine());
    }


    public void ClearGame()
    {
        SceneManager.LoadScene("LoadScene");
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        StartCoroutine(GameOverRoutine());
    }

    private IEnumerator GameOverRoutine()
    {
        Debug.Log("Routine開始");

        yield return StartCoroutine(
            fadeManager.FadeOut(2f)
        );

        Debug.Log("LoadScene開始");

        SceneManager.LoadScene("GameOverScene");
    }

    private IEnumerator ClearRoutine()
    {
        yield return new WaitForSeconds(2f);

        LoadGame2();
    }
    public void LoadGame2()         
    {
        isLoading = true;

        LoadManager.nextSceneName = "GameScene2";

        Debug.Log("次のシーン設定：" + LoadManager.nextSceneName);

        SceneManager.LoadScene("LoadScene");
    }
}
