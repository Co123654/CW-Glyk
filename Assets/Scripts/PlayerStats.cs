using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int playerLevel = 1;
    public int maxLevel = 100;
    public TMP_Text levelText;
    public int currentExp;
    public int baseExp = 1000;
    public int[] expToLevelUp;
    public Player player;
    public HealthManager health;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<HealthManager>();
        player = FindObjectOfType<Player>();
        levelText.text = "Level: " + playerLevel;
        expToLevelUp = new int[maxLevel];
        expToLevelUp[1] = baseExp;
        for (int i = 2; i < expToLevelUp.Length; i++)
        {
            expToLevelUp[i] = Mathf.FloorToInt(expToLevelUp[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentExp = player.exp;
        levelText.text = "Level: " + playerLevel;
        if (currentExp >= expToLevelUp[playerLevel + 1])
        {
            player.exp = currentExp - expToLevelUp[playerLevel + 1];
            playerLevel++;
            levelText.text = "Level: " + playerLevel;
            health.maxHealth = Mathf.RoundToInt(health.maxHealth * 1.025f);
            health.currentHealth = health.maxHealth;
        }
    }
}
