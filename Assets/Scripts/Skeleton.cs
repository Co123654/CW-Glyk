using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Animator animator;
    private Transform target;

    public Transform origin;
    
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;

    Vector2 lastvalidlocation;

    // Start is called before the first frame update
    void Start()
    {
        lastvalidlocation = origin.position;
        animator = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
            FollowPlayer();
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
            GoHome();
        lastvalidlocation = new Vector2(transform.position.x, transform.position.y);

    }

    public void FollowPlayer()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("Move X", (target.position.x - transform.position.x));
        animator.SetFloat("Move Y", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        animator.SetFloat("Move X", (origin.position.x - transform.position.x));
        animator.SetFloat("Move Y", (origin.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, origin.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, origin.position) == 0)
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Attack"))
        {
            lastvalidlocation = new Vector2(transform.position.x, transform.position.y);
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x / 1.5f, transform.position.y + difference.y / 1.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Walls"))
        {
            transform.position = lastvalidlocation;
        }
    }
}
