using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    void Start()
    {
        finalScoreText.text = "You Scored:\n" + scoreKeeper.GetScore().ToString().PadLeft(10, '0');
    }

}
