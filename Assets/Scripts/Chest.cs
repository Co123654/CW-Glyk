using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] items;
    public GameObject interactKey;

    private bool inTrigger;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactKey.SetActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactKey.SetActive(false);
            inTrigger = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && inTrigger)
        {
            animator.SetBool("Opening", true);
            Invoke(nameof(OpenChest), 0.4f);
        }

    }

    void OpenChest()
    {
        var itemToSpawn = Random.Range(0, items.Length);
        _ = Instantiate(items[itemToSpawn], transform.position, transform.rotation);
        gameObject.SetActive(false);
        animator.SetBool("Opening", false);

    }
}
