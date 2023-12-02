using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int exp;
    public string weapon;
    public float speed;
    public int damage;
    public int currenthealth;
    public int maxhealth;
    public bool hasmirrorshield;
    public float damageresistence;
    public string map;
    public float[] position;

    public PlayerData (Player player)
    {
        speed = player.speed;
        damage = player.damage;
        weapon = player.weapon;
        exp = player.exp;

        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }

}
