using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public enum NextScene
    {
        Game1,
        Game2,
        Result
    }
    public string nextSceneName;
  
    // Start is called before the first frame update

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(nextSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
