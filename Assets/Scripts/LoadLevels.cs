using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public string level;
    public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }
}
