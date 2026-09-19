using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2Manager : MonoBehaviour
{
    public void ClearGame()
    {
        StartCoroutine(ClearRoutine());
    }

    private IEnumerator ClearRoutine()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("ResultScene");
    }
}
