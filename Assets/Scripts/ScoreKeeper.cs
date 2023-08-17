using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public const int INITIAL_SCORE = 0;
    private int score = INITIAL_SCORE;

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
