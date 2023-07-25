using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    private void SpawnEnemies()
    {
        for(int i = 0; i< currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i),
                    currentWave.GetStartingtWaypoint().position,
                    Quaternion.identity,    // this means no rotation
                    transform);   // put inside the EnemySpawner when instantiating (transform of the parent)
        }
        
    }
}
