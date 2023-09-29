using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator;

    public float speed;
    private float currentSpeed;

    private HealthManager health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = FindObjectOfType<HealthManager>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
        animator.SetFloat("moveX", rb.velocity.x);
        animator.SetFloat("moveY", rb.velocity.y);

        
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastY", Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetButtonDown("Jump") && animator.GetBool("isRolling") == false)
        {
            animator.SetBool("isRolling", true);
            health.canTakeDamage = false;
            speed = speed * 1.5f;
            Invoke("Roll", 0.33f);
        }
    }

    void Roll()
    {
        animator.SetBool("isRolling", false);
        health.canTakeDamage = true;
        speed = currentSpeed;
    }
}
