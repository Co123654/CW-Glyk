using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : MonoBehaviour
{
    private Animator animator;
    private Transform playerTarget;
    public Transform target;

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

       /* switch(action)
        {
            case 1:
                Patrol();
                endPatrol = Random.Range(1, 50);
                break;
            case 2:
                Taunt();
                break;
            case 3:
                Attack();
                break;
            case 4:
                Attack();
                break;
        }*/

        if(action == 1)
        {
            Patrol();
            endPatrol = Random.Range(1, 50);
        }
        else if(action == 2)
        {
            Taunt();
        }
        else if(action >= 3)
        {
            Attack();
        }
    }

    public void SelectAction()
    {
        action = Random.Range(2, 50);
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

    void Taunt()
    {
        //Play taunt animation
        //Return
        animator.SetTrigger("Gesturing");
        actionCompleted = true;
    }

    void Attack()
    {
        if (Vector2.Distance(transform.position, playerTarget.position) > minimumDistance)
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
        else
        {
            animator.SetTrigger("Attacking");
            Invoke(nameof(SelectAction), 1.6f);
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
