using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float currentHealth;
    public float damageResitance = 1;
    public int maxHealth;
    public bool canTakeDamage;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HurtPlayer(float damageToGive)
    {
        currentHealth -= Mathf.Round(damageToGive);

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
