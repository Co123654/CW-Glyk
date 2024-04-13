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
            health.HurtPlayer(5 * health.damageResitance);
        }
        else if(other.CompareTag("Mage"))
        {
            //Check if can damage mage
            //Damage mage
        }
    }
}
