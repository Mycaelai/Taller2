using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    };
    
    [System.Serializable]
             public class Wave
             {
                 public Transform obje;
                 public int count;
                 public float rate;
             }
    
             public Wave[] waves;
             private int nextWave = 0;
    
             public float timeBetweenWaves = 5f;
             public float waveCountdown;

             private float searchCountdown = 1f;


             private SpawnState state = SpawnState.COUNTING;
    
    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveComplited();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING )
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveComplited()
    {
        Debug.Log("wave completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("all wave ok");
        }
        else
        {
          nextWave++;  
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            
            if (GameObject.FindGameObjectsWithTag("enemy") == null)
           {
               return false;
           } 
        }
        
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.obje);
            yield return new WaitForSeconds( 1f/_wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }
    
    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, transform.position, transform.rotation);
    }



}
