using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    public Transform target;

    private Minotaur minotaur;

    private Mage mage;

    public bool minormag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Mage"))
        {
            if(minormag)
            {
                minotaur = other.GetComponent<Minotaur>();
                minotaur.target = target;

            }
            else
            {
                mage = other.GetComponent<Mage>();
                mage.target = target;
            }
        }
    }
}
