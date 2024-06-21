using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string Items;
    [SerializeField]
    private string itemActivate;

    private bool insideCollider;
    public bool isShopItem;
    public int cost;

    private Item Script;
    private HealthManager health;
    public GameObject player;

    [Header("Weapons")]
    public GameObject Sword;
    public GameObject Spear;

    public GameObject OldWeapon;

    public GameObject holyAura;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Script = collision.GetComponent<Item>();
            Script.Interact();
            itemActivate = Script.itemName;
            insideCollider = true;
            isShopItem = collision.GetComponent<Item>().isShopItem;
            cost = collision.GetComponent<Item>().cost;
        }
        else if (collision.CompareTag("Drop"))
        {
            Script = collision.GetComponent<Item>();
            player.GetComponent<Player>().gold = player.GetComponent<Player>().gold + Random.Range(1, 5);
            Script.Destroy();
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        insideCollider = false;
        Script.StopInteract();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && insideCollider)
        {
            if (isShopItem && cost <= player.GetComponent<Player>().gold || !isShopItem)
            {
                player.GetComponent<Player>().gold = player.GetComponent<Player>().gold - cost;
                cost = 0;
                isShopItem = false;
                switch (itemActivate)
                {
                    case "Small Health Potion":
                        health = FindObjectOfType<HealthManager>();
                        if (health.currentHealth >= health.maxHealth - 10)
                        {
                            health.currentHealth = health.maxHealth;
                        }
                        else
                        {
                            health.currentHealth += 10;
                        }
                        Script.Destroy();
                        break;
                    case "Hollow Heart":
                        health = FindObjectOfType<HealthManager>();
                        health.maxHealth += 10;
                        Script.Destroy();
                        break;
                    case "Fragile Shield":
                        health = FindObjectOfType<HealthManager>();
                        if (health.damageResitance == 1)
                        {
                            health.damageResitance -= 0.1f;
                        }
                        else
                        {
                            health.damageResitance *= 0.95f;
                        }
                        Script.Destroy();
                        break;
                    case "Light Foot":
                        player.GetComponent<Player>().speed = player.GetComponent<Player>().speed * 1.25f;
                        player.GetComponent<Player>().currentSpeed = player.GetComponent<Player>().speed;
                        Script.Destroy();
                        break;
                    case "Holy Pendant":
                        holyAura.SetActive(true);
                        Script.Destroy();
                        break;
                    case "Mirror Shield":
                        health = FindObjectOfType<HealthManager>();
                        health.mirrorShield = true;
                        if (health.damageResitance == 1)
                        {
                            health.damageResitance -= 0.1f;
                        }
                        else
                        {
                            health.damageResitance *= 0.95f;
                        }
                        Script.Destroy();
                        break;
                    case "Sharp Ring":
                        player.GetComponent<Player>().damage++;
                        Script.Destroy();
                        break;
                }
            }
        }
    }
}
