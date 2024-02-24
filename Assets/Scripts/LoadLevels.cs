using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public string level;

    public Save player;

    public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.StatSave();
            Invoke(nameof(LoadLevel), 1f);
        }
    }
}
