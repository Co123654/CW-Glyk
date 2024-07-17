using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayerCircle : MonoBehaviour
{
    private HealthManager health;

    public float waitToHurt = 2f;
    public bool isTouching;
    public float damage = 10f;

    public bool explosive = false;

    public EnemyHealthManager enemy;

    public bool mirrorShield = false;

    public Player player;

    public Collider2D Hitcollider;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(reloading)
        {
            waitToLoad -= Time.deltaTime;
            
            if(waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }*/

        if(player.isRolling)
        {
            Hitcollider.isTrigger = true;
        }
        else
        {
            Hitcollider.isTrigger = false;
        }

        if (isTouching && health.canTakeDamage)
        {
                waitToHurt -= Time.deltaTime;
                if (waitToHurt <= 0)
                {
                    health.HurtPlayer(damage * health.damageResitance, enemy);

                    waitToHurt = 2f;
                }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && health.canTakeDamage)
        {
                health.HurtPlayer(damage * health.damageResitance, enemy);
                if (explosive)
                {
                    enemy.currentHealth = 0;
                }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }

    private void ReActivate()
    {
        Hitcollider.isTrigger = false;
    }
}
