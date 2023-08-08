using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseTimeBetweenProjectiles = 1f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float timeBetweenProjectilesVariance = 0f; // 0 means no variance, we can then add or subtract this
    [SerializeField] float minimumTimeBetweenProjectiles = 0.1f; // this is so that we dont get negative numbers with the time variance
    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;

    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if(isFiring && firingCoroutine == null) // if we are firing and the coroutine is not started
        {
            firingCoroutine = StartCoroutine(FireContinuously());   // we can store a reference to a coroutine
        }
        else if (!isFiring && firingCoroutine != null)  // else if we stopped firing
        {
            StopCoroutine(firingCoroutine); // we can stop a coroutine with its reference
            firingCoroutine = null;
        }
        
    }

    private IEnumerator FireContinuously()
    {
        do
        {
            GameObject currentProjectile = Instantiate(projectilePrefab, 
                        transform.position, // start at position of game object containing the shooter component
                        Quaternion.Euler(transform.rotation.eulerAngles));  // rotate projectile as shooter
            Rigidbody2D rigidbody = currentProjectile.GetComponent<Rigidbody2D>();
            if(rigidbody != null)
            {
                rigidbody.velocity = transform.up * projectileSpeed;    // the up "versor" (green arrow) * speed = vector
            }
            Destroy(currentProjectile, projectileLifetime);  // destroy projectile after its lifetime has passed
            yield return new WaitForSeconds(GetRandomTimeBetweenProjectiles());  // exit coroutine and come back in X seconds
        }
        while (isFiring);
    }

    private float GetRandomTimeBetweenProjectiles()
    {
        if(!useAI)
        {
            return baseTimeBetweenProjectiles;  // if no AI for this shooter, use the nominal firing rate
        }
        float actualFiringRate = UnityEngine.Random.Range( baseTimeBetweenProjectiles - timeBetweenProjectilesVariance,
                                                           baseTimeBetweenProjectiles + timeBetweenProjectilesVariance );
        return Mathf.Clamp(actualFiringRate, minimumTimeBetweenProjectiles, float.MaxValue);
    }
}
