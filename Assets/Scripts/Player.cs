using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator;

    public float speed;
    public int damage = 2;
    public float currentSpeed;

    public TMP_Text goldText;

    private readonly float attackTime = 0.25f;
    private float attackCounter = 0.25f;
    private bool isAttacking = false;
    public bool isRolling = false;

    public int gold;

    public int exp = 0;

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
        goldText.text = "Gold: " + gold.ToString();

        rb.velocity = speed * Time.deltaTime * new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        animator.SetFloat("moveX", rb.velocity.x);
        animator.SetFloat("moveY", rb.velocity.y);

        /*if (Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.M))
        {
            if (health.canTakeDamage == true)
            {
                health.canTakeDamage = false;
            }
            else
            {
                health.canTakeDamage = true;
            }
        }*/
        
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastY", Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetButtonDown("Jump") && animator.GetBool("isRolling") == false)
        {
            animator.SetBool("isRolling", true);
            health.canTakeDamage = false;
            isRolling = true;
            speed *= 1.5f;
            Invoke(nameof(Roll), 0.33f);
        }

        if(isAttacking)
        {
            rb.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && isAttacking == false)
        {
            Debug.Log(Input.mousePosition/10);
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            animator.SetInteger("Weapon", 0);
            isAttacking = true;
        }
    }

    void Roll()
    {
        animator.SetBool("isRolling", false);
        health.canTakeDamage = true;
        speed = currentSpeed;
        isRolling = false;
    }
}
