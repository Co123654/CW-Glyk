using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField]
    private GameObject LeverOff;
    [SerializeField]
    private GameObject LeverOn;
    [SerializeField]
    private GameObject Wall;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            PullTheLeverKronk();
        }
    }

    void PullTheLeverKronk()
    {
        LeverOff.SetActive(false);
        LeverOn.SetActive(true);
        Wall.SetActive(false);
    }
}