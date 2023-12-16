using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName = "";
    public GameObject interactKey;
    public bool isShopItem;
    public int cost;

    public void Interact()
    {
        interactKey.SetActive(true);
    }

    public void StopInteract()
    {
        interactKey.SetActive(false);
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
