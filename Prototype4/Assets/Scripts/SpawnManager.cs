/*
 * (Noah Trillizio)
 * (Assignment 7)
 * (Controls when enemies and powerups should spawn)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerPrefab;
    private float spawnRange = 9;

    public int enemyCount;
    public int waveNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup(1);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //instansiate the enemy in the random position
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            //instansiate the enemy in the random position
            Instantiate(powerPrefab, GenerateSpawnPosition(), powerPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        //generating a random position on the platform
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);
        }
    }
}
