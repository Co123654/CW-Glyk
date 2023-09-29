using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private HealthManager health;
    public Slider healthBar;
    public TMP_Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.currentHealth;
        hpText.text = health.currentHealth + "/" + health.maxHealth;
    }
}
