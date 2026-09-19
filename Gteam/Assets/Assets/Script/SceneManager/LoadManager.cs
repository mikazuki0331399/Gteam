using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static string nextSceneName;

    IEnumerator Start()
    {
        Debug.Log("LoadSceneŠJŽn");
        Debug.Log("nextSceneName = " + nextSceneName);

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(nextSceneName);
    }
}
