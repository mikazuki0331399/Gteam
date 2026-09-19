using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
    public void RestartBtn()
    {
        SceneManager.LoadScene("GameScene1");
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
