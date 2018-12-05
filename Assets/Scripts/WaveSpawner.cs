using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {


    public Transform spawnPoint;
    public Transform enemyPrefab;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

    public float waveCount;


    private int waveIndex = 0;

	void Update () {
        if (waveIndex < waveCount)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }

            countdown -= Time.deltaTime;
        }

	}

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
