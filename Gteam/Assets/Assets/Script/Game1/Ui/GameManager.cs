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
            Debug.Log("FINISHèåèíBê¨");
            FinishGame();
        }
    }

    public void FinishGame()
    {
        finishText.text = "FINISH!";
        finishText.gameObject.SetActive(true);
        FinishGame(finishText);
        StartCoroutine(FinishRoutine());
        StarMove[] stars = FindObjectsOfType<StarMove>();

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
       
        StartCoroutine(FinishRoutine());
    }

    private IEnumerator FinishRoutine()
    {
        yield return new WaitForSecondsRealtime(1f);

        yield return StartCoroutine(
        fadeManager.FadeOut(2f)
        );

        SceneManager.LoadScene("ResultScene");
    }


}
