using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string Items;
    [SerializeField]
    private string itemActivate;

    private bool insideCollider;

    private Item Script;
    private HealthManager health;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Item")
        {
            Script = collision.GetComponent<Item>();
            Script.Interact();
            itemActivate = Script.itemName;
            insideCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        insideCollider = false;
        Script.StopInteract();
    }

    private void Update()
    {
        if(Input.GetKeyDown("e") && insideCollider)
        {
            Debug.Log("Break");
            if(itemActivate == "Small Health Potion")
            {
                health = FindObjectOfType<HealthManager>();
                if (health.currentHealth >= health.maxHealth - 10)
                {
                    health.currentHealth = health.maxHealth;
                }
                else
                {
                    health.currentHealth = health.currentHealth + 10;
                }
                Script.Destroy();
            }
            else if(itemActivate == "Hollow Heart")
            {
                health = FindObjectOfType<HealthManager>();
                health.maxHealth = health.maxHealth + 10;
                Script.Destroy();
            }
            else if(itemActivate == "Fragile Shield")
            {
                health = FindObjectOfType<HealthManager>();
                if (health.damageResitance == 1)
                {
                    health.damageResitance = health.damageResitance - 0.1f;
                }
                else
                {
                    health.damageResitance = health.damageResitance * 0.95f;
                }
                Script.Destroy();
            }
            else if(itemActivate == "Light Foot")
            {
                player.GetComponent<Player>().speed = player.GetComponent<Player>().speed * 1.25f;
                Script.Destroy();
            }
        }
    }
}
