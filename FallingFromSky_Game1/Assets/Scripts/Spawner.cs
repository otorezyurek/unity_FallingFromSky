using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public GameObject player;

    public float timeBtwSpawns; // iki spawn arasındaki süre
    float remainingTimeBtwSpawns;   // iki spawn arasındaki kalan süre
    public float minTimeBtwSpawns;  // iki spawn arasındaki minimum süre
    public float timeDecrease;  // her bir spawndan sonra iki spawn arasındaki sürenin azalma miktarı


    void Update()
    {
        if(player != null)
		{
            SpawnEnemies();
		}
    }

    void SpawnEnemies()
	{
        if (remainingTimeBtwSpawns <= 0)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];
            Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);

            if (timeBtwSpawns > minTimeBtwSpawns)
            {
                timeBtwSpawns -= timeDecrease;
            }

            remainingTimeBtwSpawns = timeBtwSpawns;
        }
        else
        {
            remainingTimeBtwSpawns -= Time.deltaTime;
        }
    }
}
