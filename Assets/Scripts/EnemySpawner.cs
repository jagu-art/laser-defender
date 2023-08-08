using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    WaveConfigSO currentWave;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach(WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for(int i = 0; i< currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.identity,    // this means no rotation
                            transform);   // put inside the EnemySpawner when instantiating (transform of the parent)
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());  // exit coroutine and come back in X seconds
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
