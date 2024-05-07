using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int enemyKillCount = 0;

    void Update()
    {
        //counts the instances of enemys spawned in the scene
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
        {
            //spawns a new enemy
            GameObject.FindObjectOfType<EnemySpawner>().spawnEnemy();
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