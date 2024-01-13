using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : MonoBehaviour
{
    private Animator animator;
    private Transform playerTarget;
    public Transform target;

    public EnemyHealthManager minotaurHealthMan;

    private int action = 1;

    public int endPatrol;

    [SerializeField]
    private bool actionCompleted;

    [SerializeField]
    private float speed;

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
        animator.SetInteger("Health", minotaurHealthMan.currentHealth);
        if(actionCompleted)
        {
            SelectAction();
        }

        switch(action)
        {
            case 1:
                Patrol();
                endPatrol = Random.Range(1, 100);
                break;
            case 2:
                Taunt();
                break;
            case 3:
                Attack();
                break;
        }
    }

    public void SelectAction()
    {
        action = Random.Range(1, 3);
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
        if(endPatrol == Random.Range(1,100))
        {
            actionCompleted = true;
        }
    }

    void Taunt()
    {
        //Play taunt animation
        //Return
    }

    void Attack()
    {
        //Target player
        //Play attack animation
        //Activate weapon collider
        //Deactivate weapon collider
        //Return
    }
}
