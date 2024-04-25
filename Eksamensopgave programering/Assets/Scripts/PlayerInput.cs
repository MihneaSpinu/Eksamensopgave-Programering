using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Dette er farten på vores spiller
    public GameObject arrowPrefab;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private void Awake() // Awake kører før start, og vi bruger det til at hente Rigidbody2D komponenten
    {
        rb = GetComponent<Rigidbody2D>();
    }

    Vector2 movement;
    void Update() // Vi bruger void update til player inputs
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1")) // Vi bruger GetButtonDown til at se om knappen er blevet trykket ned
        {
            Shoot();
        }
    }

    void FixedUpdate() // Vi bruger fixed update til player movement da en normal update varierer pr. frametime, og FixedUpdate ikke gør
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // Vi flytter spilleren
    }

    void Shoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); // Vi bruger Mouse.current.position.ReadValue() til at få musens position
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity); // Vi instantierer en pil
        Arrow Arrow = arrow.GetComponent<Arrow>(); // Vi henter Arrow scriptet fra pilen
        Arrow.archer = gameObject; // Vi sætter archer variablen i Arrow scriptet til at være vores spiller
        Arrow.velocity = (mousePos - (Vector2)transform.position).normalized * speed; // Vi giver pilen en velocity
        arrow.transform.Rotate(0, 0, Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg); // Vi roterer pilen
        Destroy(arrow, 2f); // Vi sletter pilen efter 2 sekunder
    }
}