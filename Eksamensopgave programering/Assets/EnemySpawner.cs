using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public void spawnEnemy() // Spawns a new enemy
    {
        // Generate a random position within a radius of 8 units
        Vector3 spawnPosition = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8), 0);

        // Spawns a new enemy at the random position
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
