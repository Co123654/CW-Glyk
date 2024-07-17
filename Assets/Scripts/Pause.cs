using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pauseScreen;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Space"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
            else 
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
