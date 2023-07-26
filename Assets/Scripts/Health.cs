using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    private void OnTriggerEnter2D(Collider2D other) {
        // this will only be populated if it contains a DamageDealer component, otherwise null
        DamageDealer damageDealer = other.GetComponent<DamageDealer>(); 
        if(damageDealer != null)
        {
            // take damage
            TakeDamage(damageDealer.GetDamage());
            // tell damage dealer that it hit something
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
