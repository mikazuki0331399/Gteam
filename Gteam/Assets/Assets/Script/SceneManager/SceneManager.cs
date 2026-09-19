using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneLoader : MonoBehaviour
{
public static SceneLoader Instance;
 
private void Awake()
{
if (Instance == null)
{
Instance = this;
DontDestroyOnLoad(gameObject);
}
else
{
Destroy(gameObject);
}
}
 
public void LoadTitle()
{
SceneManager.LoadScene("TitleScene");
}
 
public void LoadStory()
{
SceneManager.LoadScene("StoryScene");
}
 
public void LoadLoad()
{
SceneManager.LoadScene("LoadScene");
}
 
public void LoadGame1()
{
SceneManager.LoadScene("Game1Scene");
}
 
public void LoadGame2()
{
SceneManager.LoadScene("Game2Scene");
}
 
public void LoadResult()
{
SceneManager.LoadScene("ResultScene");
}
}