using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class Enemy : MonoBehaviour
{

    // Declare the player stats
    public int health = 100;
    public float movementSpeed = 5f;
    public float shootCooldown;
    public int damage = 10;
    public int maxHealth = 100;

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

    void Update()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame) // Just for testing purposes
        {
            health -= 50;
        }
    }

    public void TakeDamage(int damage) // Take damage
    {
        health -= damage; // Decrease the health
        if (health <= 0) // If the health is less than or equal to 0
        {
            // Notify the game manager that the enemy died
            FindObjectOfType<GameManager>().EnemyDied();
            // Destroy the Enemy
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Damage any object that collides with the enemy
        collision.gameObject.SendMessage("TakeDamage", damage);
    }

}


