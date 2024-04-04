using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    // This function is called when the collider/rigidbody has begun touching another rigidbody/collider
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
    }
}