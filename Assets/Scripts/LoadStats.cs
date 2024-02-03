using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class LoadStats : MonoBehaviour
{
    EasyFileSave playerFile;

    public Save save;
    public Player player;
    public HealthManager health;

    // Start is called before the first frame update
    void Start()
    {
        playerFile = save.playerFile;
        player.exp = playerFile.GetInt("exp");
        player.speed = playerFile.GetFloat("speed");
        player.damage = playerFile.GetInt("damage");
        player.weapon = playerFile.GetString("weapon");
        health.maxHealth = playerFile.GetInt("maxhealth");
        health.currentHealth = playerFile.GetFloat("currenthealth");
        health.damageResitance = playerFile.GetFloat("damageresistance");
        health.mirrorShield = playerFile.GetBool("mirrorshield");
    }
}
