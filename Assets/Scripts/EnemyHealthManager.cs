using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private bool flashActive;
    public float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;
    public Slider healthBar;
    public TMP_Text hpText;
    public GameObject loot;
    public Player player;
    public bool explosive = false;
    public Animator animator;
    public string level;
    public Save save;
    public GameObject loadingScreen;
    public Slider slider;
    public bool finalBoss = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        currentHealth = maxHealth;
        enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        hpText.text = currentHealth + "/" + maxHealth;
        if (currentHealth <= 0)
        {
            if (explosive)
            {
                animator.SetTrigger("Explode");
                Invoke(nameof(Die), 0.33f);
            }
            else
            {
                player.exp += Random.Range(50, 250);
                Instantiate(loot, transform.position, transform.rotation);
                if(finalBoss)
                {
                    StartCoroutine(LoadAsync(level));
                    save.StatsReset();
                }
                Destroy(gameObject);
            }
        }
        if (flashActive)
        {
            if (flashCounter > flashLength * 0.99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 0.82f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * 0.66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 0.49f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * 0.33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 0.33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;
    }

    void Die()
    {
        Instantiate(loot, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator LoadAsync(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
