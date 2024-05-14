using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Dette er farten på vores arrow
    public GameObject arrowPrefab;
    private float lastShotTime;
    private float shootCooldown; // Cooldown in seconds
    public Rigidbody2D rb;
    private float moveSpeed; // Declare the moveSpeed variable
    private PlayerStats playerStats; // Declare the playerStats variable
    private Animator animator;

    private void Awake() // Awake kører før start, og vi bruger det til at hente Rigidbody2D komponenten
    {
        rb = GetComponent<Rigidbody2D>();
        playerStats = FindAnyObjectByType<PlayerStats>();
        shootCooldown = playerStats.shootCooldown;
        moveSpeed = playerStats.movementSpeed;
        animator = GetComponent<Animator>();
    }

    Vector2 movement;
    void Update() // Vi bruger void update til player inputs
    {
        shootCooldown = playerStats.shootCooldown; // Update the shoot cooldown
        moveSpeed = playerStats.movementSpeed; // Update the move speed
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        if (Input.GetButton("Fire1") && Time.time - lastShotTime > shootCooldown) // Check if enough time has passed since the last shot
        {
            Shoot();
            lastShotTime = Time.time; // Update the last shot time
        }
    }

    void FixedUpdate() // Vi bruger fixed update til player movement da en normal update varierer pr. frametime, og FixedUpdate ikke gør
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // Vi flytter spilleren
    }

    void Shoot()
    {
        // Vi bruger Mouse.current.position.ReadValue() til at få musens position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // Vi instantierer en pil 
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        // Vi henter Arrow scriptet fra pilen
        Arrow Arrow = arrow.GetComponent<Arrow>();
        // Vi sætter archer variablen i Arrow scriptet til at være vores spiller
        Arrow.archer = gameObject;
        // Vi giver pilen en fart
        Arrow.velocity = (mousePos - (Vector2)transform.position).normalized * speed;
        // Vi roterer pilen så den peger mod musen
        arrow.transform.Rotate(0, 0, Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg);
        // Vi sletter pilen efter 2 sekunder
        Destroy(arrow, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger!");
    }
}