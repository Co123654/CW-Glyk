using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBullet : MonoBehaviour
{
    public Transform player;
    public Transform mage;
    public Transform target;

    private HealthManager health;

    private float speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        mage = FindObjectOfType<Mage>().transform;
        target = player;
        health = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (target.position == null)
        {
            Destroy(gameObject);
        }
        Debug.Log(target.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Attack"))
        {
            target = mage;
            speed++;
            //Enable damage to mage
        }
        else if(other.CompareTag("Player"))
        {
            health.HurtPlayer(5 * health.damageResitance, mage.GetComponent<EnemyHealthManager>());
            Destroy(gameObject);
        }
        else if(other.CompareTag("Mage"))
        {
            if(target == mage)
            {
                EnemyHealthManager enemyHealth;
                enemyHealth = other.gameObject.GetComponent<EnemyHealthManager>();
                enemyHealth.HurtEnemy(10);
                Destroy(gameObject);
            }
        }
    }
}
