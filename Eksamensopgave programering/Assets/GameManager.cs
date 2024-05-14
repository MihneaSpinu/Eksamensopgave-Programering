using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int enemyKillCount = 0;
    public float delay = 50f;

    void Update()
    {
        //counts the instances of enemys spawned in the scene
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 10)
        {
            //spawns a new enemy
            GameObject.FindObjectOfType<EnemySpawner>().spawnEnemy();
            // Wait for the specified delay before spawning a new enemy
            StartCoroutine(SpawnEnemyWithDelay(delay));

            IEnumerator SpawnEnemyWithDelay(float delay)
            {
                yield return new WaitForSeconds(delay);
                GameObject.FindObjectOfType<EnemySpawner>().spawnEnemy();
            }
           
        }
    }

    public void EnemyDied()
    {
        // Increment the enemy kill count
        enemyKillCount++;

        // Declare and initialize the playerLevel variable
        PlayerLevel playerLevel = FindObjectOfType<PlayerLevel>();

        // Gain experience for killing an enemy
        playerLevel.GainExperience(10); // assuming 100 is the experience gained per kill
    }
}