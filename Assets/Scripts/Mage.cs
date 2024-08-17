using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    private Animator animator;
    private Transform playerTarget;
    public Transform target;
    public Transform bulletSpawner;

    public GameObject mageBullet;
    public GameObject Fireball;

    public bool bossHasStarted = false;

    public EnemyHealthManager minotaurHealthMan;

    public int action = 1;

    public int endPatrol = 46;

    [SerializeField]
    private bool actionCompleted;

    [SerializeField]
    private float speed;

    public float minimumDistance;

    // Start is called before the first frame update
    void Start()
    {
        minotaurHealthMan = GetComponent<EnemyHealthManager>();
        animator = GetComponent<Animator>();
        playerTarget = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        endPatrol = Random.Range(1, 200);

        if (minotaurHealthMan.currentHealth <= 0)
        {
            this.transform.position = new Vector3(1257.5f, 12, 0);
            action = 4;
            speed = 0;
            //animator.SetTrigger("Dead");
            //Invoke(nameof(Destroy), 1.5f);
            return;
        }

        animator.SetInteger("Health", minotaurHealthMan.currentHealth);
        if(actionCompleted)
        {
            StopAllCoroutines();
            SelectAction();
            switch(action)
            {
                case 1:
                    Patrol();
                    endPatrol = Random.Range(1, 150);
                    actionCompleted = false;
                    break;
                case 2:
                    actionCompleted = false;
                    StartCoroutine(Fire());
                    break;
                case 3:
                    StartCoroutine(Attack());
                    actionCompleted = false;
                    break;
            }
        }

        animator.SetBool("isMoving", true);
        animator.SetFloat("MoveX", (target.position.x - transform.position.x));
        animator.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void SelectAction()
    {
        if (action == 1)
        {
            action = Random.Range(2, 4);
        }
        else
        {
            action = 1;
        }
        Debug.Log(action);
        StopAllCoroutines();
    }

    void Patrol()
    {
        //Move to first point
        //Each point changes target
        //Randomly decide to return
        //Return
        if(endPatrol == Random.Range(1,200) && bossHasStarted)
        {
            actionCompleted = true;
        }
    }

    IEnumerator Fire()
    {
        //Shoot 3 Fireballs
        //Return
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Fireball, bulletSpawner.position, bulletSpawner.rotation);
            yield return new WaitForSeconds(1);
        }
        actionCompleted = true;
    }

    IEnumerator Attack()
    {
        Debug.Log("Trigger");
        for (int i = 0; i < 12; i++)
        {
            Instantiate(mageBullet, bulletSpawner.position, bulletSpawner.rotation);
            yield return i;
        }
        actionCompleted = true;
        yield break;

    }

    void Destroy()
    {
        Destroy(Fireball);
        //Destroy(this.gameObject);
    }
}
