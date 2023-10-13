using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;

    private Player player;

    bool AOE = false;

    public float waitToHurt = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        damageToGive = player.damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && !AOE)
        {
            EnemyHealthManager enemyHealth;
            enemyHealth = other.gameObject.GetComponent<EnemyHealthManager>();
            enemyHealth.HurtEnemy(damageToGive);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(AOE)
        {
            if (other.tag == "Enemy")
            {
                EnemyHealthManager enemyHealth;
                enemyHealth = other.gameObject.GetComponent<EnemyHealthManager>();
                waitToHurt -= Time.deltaTime;
                if(waitToHurt == 0)
                {
                    enemyHealth.HurtEnemy(damageToGive);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        waitToHurt = 2f;
    }
}
