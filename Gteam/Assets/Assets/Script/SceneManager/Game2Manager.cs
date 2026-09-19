using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2Manager : MonoBehaviour
{
    public void ClearGame()
    {
        SceneManager.LoadScene("GameClearScene");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

   
}
