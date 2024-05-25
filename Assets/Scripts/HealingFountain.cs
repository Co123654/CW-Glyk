using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountain : MonoBehaviour
{
    [SerializeField]
    private GameObject FullFountain;
    [SerializeField]
    private GameObject EmptyFountain;

    private bool canHeal = true;
    private bool inCollider = false;

    public HealthManager player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inCollider = false;
        }
    }

    private void Update()
    {
        if (canHeal && inCollider && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacted");
            //Heal Player 20%
            player.currentHealth += Mathf.RoundToInt(player.maxHealth * 0.2f);
            canHeal = false;
            FullFountain.SetActive(false);
        }
    }
}
