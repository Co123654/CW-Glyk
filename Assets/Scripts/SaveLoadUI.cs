using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadUI : MonoBehaviour
{
    public Player player;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPLayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        player.exp = data.exp;
        player.speed = data.speed;
        player.damage = data.damage;
        player.weapon = data.weapon;

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];

        player.transform.position = position;
    }
}
