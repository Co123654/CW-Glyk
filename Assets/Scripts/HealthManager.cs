using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float currentHealth;
    public float damageResitance = 1;
    public int maxHealth;
    public bool canTakeDamage;
    private bool flashActive;
    public float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;
    public bool mirrorShield = false;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flashActive)
        {
            if (flashCounter > flashLength * 0.99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 0.82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * 0.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 0.49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * 0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void HurtPlayer(float damageToGive, EnemyHealthManager enemy)
    {
        currentHealth -= Mathf.Round(damageToGive);
        if (mirrorShield)
        {
            enemy.currentHealth -= Mathf.RoundToInt(damageToGive / 10);
        }

        flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {
            gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
