using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGuy : MonoBehaviour
{
    private readonly Animator animator;

    public Animator attackAnim;

    private Transform target;
    [SerializeField]
    private Transform center;

    public bool actionCompleted;

    public int action = 1;

    [SerializeField]
    private float speed;

    public float minDistance;

    public GameObject tentacle;
    public GameObject waveCircle;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
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
        else if(action == 2)
        {
            WaveAttack();
        }
        else if(action == 3)
        {
            actionCompleted = true;
        }
    }

    public void SelectAction()
    {
        waveCircle.SetActive(false);
        attackAnim.SetBool("Attack", false);
        if (action == 3)
            action = Random.Range(1, 3);
        else
            action = Random.Range(1, 4);
        Debug.Log(action);
        timer = 0;
    }

    void AttackNFollow()
    {
        target = FindObjectOfType<Player>().transform;
        minDistance = 3;
        if (Vector3.Distance(target.position, transform.position) >= minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            attackAnim.SetBool("Attack", false);
        }
        else
        {
            attackAnim.SetBool("Attack", true);
            if (timer >= 0.5)
            {
                actionCompleted = true;
            }

        }
    }

    void WaveAttack()
    {
        target = center;
        minDistance = 0.01f;
        if (Vector3.Distance(target.position, transform.position) >= minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            waveCircle.SetActive(true);
            action = 4;
            Invoke("SelectAction", 2.9f);
        }
    }

    void SummonReinforcements()
    {
        target = FindObjectOfType<Player>().transform;
        Instantiate(tentacle, target.position, Quaternion.identity);
        actionCompleted = true; 
    }

    public void StartBattle()
    {
        timer = 0;
        speed = 2;
        animator.SetBool("Entrance", true);
        if(timer >= 0.5)
            animator.SetBool("Entrance", false);
        actionCompleted = true;
    }
}
