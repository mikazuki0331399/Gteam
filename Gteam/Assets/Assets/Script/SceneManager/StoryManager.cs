using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public float waitTime = 10f;

    private float timer;
    private bool isLoading;

    void Update()
    {
        if (isLoading)
        {
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadGame1();
        }

        if (timer >= waitTime)
        {
            LoadGame1();
        }
    }

    private void LoadGame1()
    {
        isLoading = true;

        LoadManager.nextSceneName = "GameScene1";

        Debug.Log("Ÿ‚ÌƒV[ƒ“İ’èF" + LoadManager.nextSceneName);

        SceneManager.LoadScene("LoadScene");
    }
}
