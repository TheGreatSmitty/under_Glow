using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigi;
    private Collider2D collison;
    
    private SpriteRenderer childobject;
    private Animator anim;

    public float speed;
    private Vector2 direction;

    private bool ground;
    //Health
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBar;

    bool damageTime;
    public void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        collison = GetComponent<Collider2D>();
        childobject = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        damageTime = false;
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }

    public void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Horizontal") > 0)
        {
            if (damageTime != true)  anim.Play("HeroWalkCycle_Right");
            if (Input.GetAxisRaw("Horizontal") < 0){ childobject.flipX = true; }
            else { childobject.flipX = false; }
            direction.x = speed * Input.GetAxis("Horizontal");
        }else
        {
            direction.x = 0;
        }

        rigi.MovePosition(rigi.position + direction * Time.fixedDeltaTime);
    }
    public void Update()
    {
        if (currentHealth <= 0)
        {
            anim.Play("Hero Die");
        }

        if (ground)
        {
            rigi.gravityScale = 10;
        }
        else
        {
            rigi.gravityScale = 20;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && maxHealth > 0)
        {
            currentHealth--;
            if (damageTime != true) { anim.Play("HeroDamage"); }
            healthBar.SetHealth(currentHealth);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Background"))
           ground = true;
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        ground = false;
    }
}
