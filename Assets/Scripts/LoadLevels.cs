using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevels : MonoBehaviour
{
    public string level;

    public Save player;

    public bool save = true;

    public bool reset = false;

    [SerializeField]
    private bool titleScreen;

    public GameObject loadingScreen;
    public Slider slider;

    public bool bossKilled;
    private void Start()
    {
        if(titleScreen)
        {
            level = player.playerFile.GetString("Level");
            if(level == null)
            {
                level = "Level1";
            }
        }
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadAsync(level));
        if(reset)
        {
            player.StatsReset();
        }
    }

    IEnumerator LoadAsync(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while(operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(save)
                player.StatSave();
            if (bossKilled)
            {
                loadingScreen.SetActive(true);
                Invoke(nameof(LoadLevel), 1f);
            }
        }
    }
}
