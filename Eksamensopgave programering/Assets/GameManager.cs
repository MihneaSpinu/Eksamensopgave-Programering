using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyKillCount = 0;
    // Update is called once per frame
    void Update()
    {
        //counts the instances of enemys spawned in the scene
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
        {
            // Generate a random position within a radius of 8 units
            Vector3 spawnPosition = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8), 0);

            // Spawns a new enemy at the random position
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void EnemyDied()
    {
        // Increment the enemy kill count
        enemyKillCount++;
    }
}