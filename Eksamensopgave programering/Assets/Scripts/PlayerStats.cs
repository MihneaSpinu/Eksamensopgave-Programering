using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{

    public int health = 100;
    public float movementSpeed = 5f;
    public float shootCooldown;

    void Update()
    {

        if (Keyboard.current.upArrowKey.isPressed)
        {
            movementSpeed += 1f;
        }

        if (Keyboard.current.downArrowKey.isPressed)
        {
            movementSpeed -= 1f;
        }

    }
}
