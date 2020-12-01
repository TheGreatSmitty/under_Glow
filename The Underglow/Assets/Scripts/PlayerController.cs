using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigi;
    private Collider2D collison;
    
    private SpriteRenderer childobject;

    public float speed;
    private Vector2 direction;

    //Health
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBar;
    public void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        collison = GetComponent<Collider2D>();
        childobject = GetComponentInChildren<SpriteRenderer>();

        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }

    public void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Horizontal") > 0)
        {
            if (Input.GetAxisRaw("Horizontal") < 0){ childobject.flipX = true; }
            else { childobject.flipX = false; }
            direction.x = speed * Input.GetAxis("Horizontal");
        }else
        {
            direction.x = 0;
        }

        rigi.MovePosition(rigi.position + direction * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth--;

            healthBar.SetHealth(currentHealth);
        }
    }
}
