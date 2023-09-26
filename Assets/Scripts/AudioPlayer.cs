using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f; //1 is full volume

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f; //1 is full volume

    private static AudioPlayer instance;

    // public AudioPlayer GetInstance() // we could use this, but globally accessible singletons are hard to manage
    // {
    //     return instance;
    // }

    private void Awake() {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        // int instanceCount = FindObjectsOfType(GetType()).Length; // old way singleton
        // if(instanceCount > 1)
        if(instance != null)    // better singleton
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

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }
    }

}
