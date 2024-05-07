using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    // Declare the player stats
    public int health = 100;
    public float movementSpeed = 5f;
    public float shootCooldown;
    public int damage = 10;
    public int maxHealth = 100;
    public int level = 0; 

    public void LevelUp() // Level up the player
    {
        level++; // Increment the level
        maxHealth += 10; // Increase the max health
        health = maxHealth; // Reset the health
        movementSpeed += 1; // Increase the movement speed
        damage += 5; // Increase the damage
        shootCooldown -= 0.5f; // Decrease the shoot cooldown
    }

    public void TakeDamage(int damage) // Take damage
    {
        health -= damage; // Decrease the health
        if (health <= 0) // If the health is less than or equal to 0
        {
            // Destroy the player
            Destroy(gameObject);
        }
    }

    void Update() 
    {
        if (Keyboard.current.gKey.wasPressedThisFrame) // Just for testing purposes
        {
            health -= 50;
        }
    }
}