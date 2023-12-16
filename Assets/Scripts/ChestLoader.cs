using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLoader : MonoBehaviour
{
    public GameObject[] chests;
    public bool[] morechests;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < chests.Length; i++)
        {
            if(chests[i].activeSelf)
            {
                morechests[i] = true;
            }
            else
            {
                morechests[i] = false;
            }
        }
    }
    public void Save()
    {
        for (int i = 0; i < chests.Length; i++)
        {
            if (chests[i].activeSelf)
            {
                morechests[i] = true;
            }
            else
            {
                morechests[i] = false;
            }
        }
    }
    public void Load()
    {
        for (int i = 0; i < chests.Length; i++)
        {
            if (morechests[i])
            {
                chests[i].SetActive(true);
            }
            else
            {
                chests[i].SetActive(false);
            }
        }
    }
}
