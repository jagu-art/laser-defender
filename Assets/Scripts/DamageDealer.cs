using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;
    
    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        // we are automatically destroying the damage dealer when it hits something
        // we could have some variants that actually only take damage
        Destroy(gameObject);
    }
}
