using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private bool SlowPlayer = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Archer")
        {
            SlowPlayer = true;
            Debug.Log("Player Slowed");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Archer")
        {
            SlowPlayer = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
