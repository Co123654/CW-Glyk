using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    public Transform target;

    private Minotaur minotaur;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            minotaur = other.GetComponent<Minotaur>();
            minotaur.target = target;
        }
    }
}
