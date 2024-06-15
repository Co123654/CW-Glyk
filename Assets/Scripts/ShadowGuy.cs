using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGuy : MonoBehaviour
{
    private Animator animator;

    public Animator attackAnim;

    private Transform target;
    [SerializeField]
    private Transform center;

    [SerializeField]
    private bool actionCompleted;

    public int action = 1;

    [SerializeField]
    private float speed;

    public float minDistance;

    public GameObject tentacle;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (actionCompleted)
        {
            SelectAction();
            switch (action)
            {
                case 1:
                    //follow player and attack
                    AttackNFollow();
                    actionCompleted = false;
                    break;
                case 2:
                    WaveAttack();
                    actionCompleted = false;
                    break;
                case 3:
                    SummonReinforcements();
                    actionCompleted = false;
                    break;
            }
        }

        if(action == 1)
        {
            AttackNFollow();
        }
    }

    public void SelectAction()
    {
        action = Random.Range(1, 4);
        Debug.Log(action);
    }

    void AttackNFollow()
    {
        target = FindObjectOfType<Player>().transform;
        minDistance = 2;
        if (Vector3.Distance(target.position, transform.position) >= minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            if((target.position.x - transform.position.x) >= 0.01 && (target.position.y - transform.position.y) >= 0.01)
            {
                attackAnim.SetFloat("X", -1);
                attackAnim.SetFloat("Y", 1);
                actionCompleted = true;
            }
            else if((target.position.x - transform.position.x) <= -0.01 && (target.position.y - transform.position.y) <= -0.01)
            {
                attackAnim.SetFloat("X", 1);
                attackAnim.SetFloat("Y", -1);
                actionCompleted = true;
            }
            else if((target.position.x - transform.position.x) >= 0.01 && (target.position.y - transform.position.y) <= -0.01)
            {
                attackAnim.SetFloat("X", -1);
                attackAnim.SetFloat("Y", -1);
                actionCompleted = true;
            }
            else if((target.position.x - transform.position.x) <= -0.01 && (target.position.y - transform.position.y) >= 0.01)
            {
                attackAnim.SetFloat("X", 1);
                attackAnim.SetFloat("Y", 1);
                actionCompleted = true;
            }
        }
    }

    void WaveAttack()
    {
        target = center;
        minDistance = 0;
        if (Vector3.Distance(target.position, transform.position) >= minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //attack
        }
    }

    void SummonReinforcements()
    {
        Instantiate(tentacle, target.position, Quaternion.identity);
        actionCompleted = true;
    }

    public void StartBattle()
    {
        animator.SetTrigger("Entrance");
        speed = 2;
    }
}
