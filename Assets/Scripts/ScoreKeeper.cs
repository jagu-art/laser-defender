using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public const int INITIAL_SCORE = 0;
    private int score = INITIAL_SCORE;

    private static ScoreKeeper instance;

    private void Awake() {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);    // other game objects might try to access the game object before we destroy it
            Destroy(gameObject);    // destroy new game objects if there is already one
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // dont destroy when loading a new scene
        }
    }

    public int GetScore()
    {
        return this.score;
    }

    public void SetScore(int score)
    {
        this.score = score;
        Mathf.Clamp(score, INITIAL_SCORE, int.MaxValue);
    }

    public void ResetScore()
    {
        this.score = INITIAL_SCORE;
    }
}
