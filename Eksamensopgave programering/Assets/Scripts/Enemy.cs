using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemyHealth = 100; // Health of the enemy

    public int health = 100; // Declare the health of the enemy
    public int damage = 10; // Declare the damage of the enemy
    [SerializeField] Transform target;
    NavMeshAgent agent;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.position);
    }

    public void TakeDamage(int damage) // Take damage
    {
        enemyHealth -= damage; // Decrease the health
        if (enemyHealth <= 0) // If the health is less than or equal to 0
        {
            // Notify the game manager that the enemy died
            FindObjectOfType<GameManager>().EnemyDied();

            // Notify the player stats that the player gained experience
            PlayerStats playerStats = FindAnyObjectByType<PlayerStats>();
            playerStats.experience += 10;

            // Destroy the Enemy
            Destroy(gameObject);
        }
    }

}
 