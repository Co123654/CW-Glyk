using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager health;

    public float waitToHurt = 2f;
    public bool isTouching;
    public float damage = 10f;

    public EnemyHealthManager enemy;

    public bool mirrorShield = false;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<HealthManager>();
        enemy = FindObjectOfType<EnemyHealthManager>();
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

        if(isTouching && health.canTakeDamage)
        {
            waitToHurt -= Time.deltaTime;
            if(waitToHurt <= 0)
            {
                health.HurtPlayer(damage * health.damageResitance, enemy);

                waitToHurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player" && health.canTakeDamage)
        {
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            health.HurtPlayer(damage * health.damageResitance, enemy);
            //reloading = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;

            waitToHurt = 2f;
        }
    }
}
