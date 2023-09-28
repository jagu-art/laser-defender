using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2.0f;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game"); // we can use the index or name of the scene
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // we can use the index or name of the scene
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadSceneAfterDelay("GameOver", sceneLoadDelay)); 
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);  // we can use the index or name of the scene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit(); // will not work in WebGL / mobile for example
    }
}
