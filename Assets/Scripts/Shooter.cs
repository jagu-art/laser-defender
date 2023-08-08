using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 1f;

    Coroutine firingCoroutine;

    public bool isFiring;
    void Start()
    {
        
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
                        Quaternion.identity);
            Rigidbody2D rigidbody = currentProjectile.GetComponent<Rigidbody2D>();
            if(rigidbody != null)
            {
                rigidbody.velocity = transform.up * projectileSpeed;    // the up "versor" (green arrow) * speed = vector
            }
            Destroy(currentProjectile, projectileLifetime);  // destroy projectile after its lifetime has passed
            yield return new WaitForSeconds(firingRate);  // exit coroutine and come back in X seconds
        }
        while (isFiring);
    }
}
