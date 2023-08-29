using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI score;
    ScoreKeeper scoreKeeper;
    
    [Header("Health")]
    [SerializeField] Health playerHealth;   // adding the player prefab here, it will be casted and its Health component will be fetched
    [SerializeField] Slider healthBar;
    
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    // Start is called before the first frame update
    void Start()
    {
        score.text = "0".PadLeft(10, '0');
        healthBar.maxValue = playerHealth.GetHealth();
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreKeeper.GetScore().ToString().PadLeft(10, '0');
        healthBar.value = playerHealth.GetHealth();
    }
}
