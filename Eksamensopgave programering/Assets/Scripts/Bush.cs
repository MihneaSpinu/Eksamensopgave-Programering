using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) // This function is called when the collider/rigidbody has begun touching another rigidbody/collider
    {
        Debug.Log("Collision Detected");
        if (other.GetComponent<Collider2D>().gameObject.tag == "Player") // If the object that collided with the bush has the tag "Player"
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            playerStats.movementSpeed /= 2; // Slow the player down
            Debug.Log("Player Slowed");
        }
    }

    void OnTriggerExit2D(Collider2D other) // This function is called when the collider/rigidbody has stopped touching another rigidbody/collider
    {
        Debug.Log("Collision Ended");
        if (other.GetComponent<Collider2D>().gameObject.tag == "Player") // If the object that collided with the bush has the tag "Player"
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            playerStats.movementSpeed *= 2; // Restore the player's speed
            Debug.Log("Player Speed Restored");
        }
    }
}