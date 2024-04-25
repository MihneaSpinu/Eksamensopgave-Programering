using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public GameObject archer;

    void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime;

        Debug.DrawLine(currentPosition, newPosition, Color.red);

        RaycastHit2D[] hits = Physics2D.LinecastAll(currentPosition, newPosition);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject != archer)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    // Destroy the enemy
                    Destroy(hit.collider.gameObject);
                    // Notify the game manager that the enemy died
                    FindObjectOfType<GameManager>().EnemyDied();
                }
                if (hit.collider.gameObject.tag == "Obstacle")
                {
                    Destroy(gameObject);
                }
            }
        }
        transform.position = newPosition;
    }
}
