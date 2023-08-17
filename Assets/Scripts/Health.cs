using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    [SerializeField] bool isPlayer;

    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();  // camera already has this way of finding it with .main
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // this will only be populated if it contains a DamageDealer component, otherwise null
        DamageDealer damageDealer = other.GetComponent<DamageDealer>(); 
        if(damageDealer != null)
        {
            // take damage
            TakeDamage(damageDealer.GetDamage());
            // show hit effect
            PlayHitEffect();
            // play damage audio
            audioPlayer.PlayDamageClip();
            // shake camera
            ShakeCamera();
            // tell damage dealer that it hit something
            damageDealer.Hit();
        }
    }

    private void ShakeCamera()
    {
        if(applyCameraShake && cameraShake != null)
        {
            cameraShake.Play();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);   // destroy after particle effect FULL duration
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void Die()
    {
        UpdateScore();
        Destroy(gameObject);
    }
    private void UpdateScore()
    {
        if(this.isPlayer) return;
        
        scoreKeeper.SetScore(scoreKeeper.GetScore() + score);   // update score if destroyed health object is not player
        Debug.Log("Score" + scoreKeeper.GetScore());
    }
}
