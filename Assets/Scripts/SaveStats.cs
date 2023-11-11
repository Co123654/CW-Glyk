using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStats : MonoBehaviour
{
    public void SaveInt(string Name, int Value)
    {
        PlayerPrefs.SetInt(Name, Value);
    }

    public void SaveFloat(string Name, float Value)
    {
        PlayerPrefs.SetFloat(Name, Value);
    }

    public void SaveString(string Name, string Value)
    {
        PlayerPrefs.SetString(Name, Value);
    }
}
