using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public GameObject arrowPrefab;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    Vector2 movement;
    void Update() // Vi bruger void update til player inputs
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void FixedUpdate() // Vi bruger fixed update til player movement da en normal update varierer pr. frametime, og FixedUpdate ikke gør
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); // Vi bruger Mouse.current.position.ReadValue() til at få musens position
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity); // Vi instantierer en pil
        arrow.GetComponent<Arrow>().velocity = (mousePos - (Vector2)transform.position).normalized * speed; // Vi giver pilen en velocity
        arrow.transform.Rotate(0, 0, Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg); // Vi roterer pilen
        Destroy(arrow, 2f);
    }
}

