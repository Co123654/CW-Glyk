using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGuy : MonoBehaviour
{
    private Animator animator;
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
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (actionCompleted)
        {
            StopAllCoroutines();
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

    void AttackNFollow()
    {
        if (Vector3.Distance(target.position, transform.position) >= minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //attack
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
}
