using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToDelete : MonoBehaviour
{
    ShadowGuy guy;

    // Start is called before the first frame update
    void Start()
    {
        guy = FindObjectOfType<ShadowGuy>();
        Invoke(nameof(Delete), 1f);
    }

    void Delete()
    {
        guy.actionCompleted = true;
        Debug.Log("C");
        Destroy(gameObject);
    }
}
