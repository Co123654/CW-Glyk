using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delete", 1f);
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
}
