using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    EasyFileSave playerFile;

    public Player player;
    public HealthManager health;
    public CameraController controller;
    public ChestLoader chest;

    // Start is called before the first frame update
    void Start()
    {
        playerFile = new EasyFileSave();
        playerFile.suppressWarning = false;
        if (playerFile.Load())
        {
            player.exp = playerFile.GetInt("exp");
            player.speed = playerFile.GetFloat("speed");
            player.damage = playerFile.GetInt("damage");
            player.transform.position = playerFile.GetUnityVector3("position");
            player.weapon = playerFile.GetString("weapon");
            health.maxHealth = playerFile.GetInt("maxhealth");
            health.currentHealth = playerFile.GetFloat("currenthealth");
            health.damageResitance = playerFile.GetFloat("damageresistance");
            health.mirrorShield = playerFile.GetBool("mirrorshield");
            controller.minPos = playerFile.GetUnityVector2("mincampos");
            controller.maxPos = playerFile.GetUnityVector2("maxcampos");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            chest.Save();
            playerFile.Add("exp", player.exp);
            playerFile.Add("speed", player.speed);
            playerFile.Add("damage", player.damage);
            playerFile.Add("position", player.transform.position);
            playerFile.Add("weapon", player.weapon);
            playerFile.Add("currenthealth", health.currentHealth);
            playerFile.Add("maxhealth", health.maxHealth);
            playerFile.Add("damageresistance", health.damageResitance);
            playerFile.Add("mirrorshield", health.mirrorShield);
            playerFile.Add("mincampos", controller.minPos);
            playerFile.Add("maxcampos", controller.maxPos);
            playerFile.Add("morechests", chest.morechests);
            playerFile.Add("chests", chest.chests);

            playerFile.Save();
            Debug.Log(Application.persistentDataPath);
            Debug.Log("Saved!");
        }

        if(Input.GetKeyUp(KeyCode.G))
        {
            //string currentSceneName = SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(currentSceneName);

            if(playerFile.Load())
            {

                player.exp = playerFile.GetInt("exp");
                player.speed = playerFile.GetFloat("speed");
                player.damage = playerFile.GetInt("damage");
                player.transform.position = playerFile.GetUnityVector3("position");
                player.weapon = playerFile.GetString("weapon");
                health.maxHealth = playerFile.GetInt("maxhealth");
                health.currentHealth = playerFile.GetFloat("currenthealth");
                health.damageResitance = playerFile.GetFloat("damageresistance");
                health.mirrorShield = playerFile.GetBool("mirrorshield");
                controller.minPos = playerFile.GetUnityVector2("mincampos");
                controller.maxPos = playerFile.GetUnityVector2("maxcampos");
                chest.morechests = playerFile.GetArray<bool>("morechests");
                chest.Load();
                Debug.Log("Loaded!");
            }
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            playerFile.Delete();
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
