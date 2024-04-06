using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    private Animator animator;
    private Transform playerTarget;
    public Transform target;

    public GameObject mageBullet;
    public GameObject Fireball;

    public bool bossHasStarted = false;

    public EnemyHealthManager minotaurHealthMan;

    public int action = 1;

    public int endPatrol;

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
        if(minotaurHealthMan.currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
            Invoke(nameof(Destroy), 1.5f);
            return;
        }

        animator.SetInteger("Health", minotaurHealthMan.currentHealth);
        if(actionCompleted)
        {
            SelectAction();
        }

        switch(action)
        {
            case 1:
                Patrol();
                endPatrol = Random.Range(1, 50);
                break;
            case 2:
                Fire();
                break;
            case 3:
                Attack();
                break;
        }
    }

    public void SelectAction()
    {
        action = Random.Range(1, 4);
        actionCompleted = false;
    }

    void Patrol()
    {
        //Move to first point
        //Each point changes target
        //Randomly decide to return
        //Return
        animator.SetBool("isMoving", true);
        animator.SetFloat("MoveX", (target.position.x - transform.position.x));
        animator.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if(endPatrol == Random.Range(1,50) && bossHasStarted)
        {
            actionCompleted = true;
        }
    }

    void Fire()
    {
        //Shoot 3 Fireballs
        //Return
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Fireball, transform.position, transform.rotation);
        }
            actionCompleted = true;
    }

    void Attack()
    {
        //Shoot mage bullets
        //Return
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
