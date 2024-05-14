using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public void spawnEnemy() // Spawns a new enemy
    {
        // Get the position of the EnemySpawner object
        Vector3 spawnerPosition = transform.position;

        // Define the boundaries of the spawn area relative to the spawner position placed in Unity
        float minX = spawnerPosition.x - 55f;
        float maxX = spawnerPosition.x + 55f;
        float minY = spawnerPosition.y - 37f;
        float maxY = spawnerPosition.y + 37f;

        // Generate a random position within the defined boundaries
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), spawnerPosition.z);

        // Spawns a new enemy at the random position
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}