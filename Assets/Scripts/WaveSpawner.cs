using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {


    public Transform spawnPoint;
    public Transform enemyPrefab;

    public GameObject fastEnemyPrefab;
    public GameObject armoredEnemyPrefab;
    public GameObject greatEnemyPrefab;
    public GameObject usualEnemyPrefab;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

    public float waveCount;

    public Attack attack;

    private int waveIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnAttackCo());
    }
    //void Update () {
    //       if (waveIndex < waveCount)
    //       {
    //           if (countdown <= 0f)
    //           {
    //               StartCoroutine(SpawnWave());
    //               countdown = timeBetweenWaves;
    //           }

    //           countdown -= Time.deltaTime;
    //       }

    //}

    //   IEnumerator SpawnWave()
    //   {
    //       waveIndex++;
    //       SpawnEnemy();
    //       //for (int i = 0; i < waveIndex; i++)
    //       //{
    //       //    SpawnEnemy();
    //       //    yield return new WaitForSeconds(0.5f);
    //       //}
    //       yield return null;

    //   }


    public void SpawnAttack()
    {
        
    }

    IEnumerator SpawnAttackCo()
    {

        for (int i = 0; i < attack.waves.Count; i++)
        {
            for (int f = 0; f < attack.waves[i].countOfFast; f++)
            {
                Instantiate(fastEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(0.3f);
            }

            for(int u = 0; u < attack.waves[i].countOfUsual; u++)
            {
                Instantiate(usualEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(0.3f);
            }

            for(int a = 0; a < attack.waves[i].countOfArmored; a++)
            {
                Instantiate(armoredEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(0.3f);
            }

            for (int g = 0; g < attack.waves[i].countOfGreat; g++)
            {
                Instantiate(greatEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(0.3f);
            }
        }

    }


    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
