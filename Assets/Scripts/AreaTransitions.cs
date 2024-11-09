using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    private CameraController cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;
    public float camSize = 5;
    public Vector3 movePlayer;

    public bool bossTrigger;

    public bool mageFight = false;

    public bool finalBoss = false;

    [SerializeField]
    private Minotaur minotaur;
    [SerializeField]
    private Mage mage;
    [SerializeField]
    private ShadowGuy shadowGuy;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPos = newMinPos;
            cam.maxPos = newMaxPos;
            cam.camSize = camSize;
            other.transform.position += movePlayer;
        }

        if (finalBoss)
        { 
            shadowGuy.StartBattle();
        }

        if(bossTrigger && !mageFight)
        {
            minotaur.bossHasStarted = true;
            minotaur.action = 2;
        }
        else if(!bossTrigger && !mageFight) 
        {
            minotaur.bossHasStarted = false;
            minotaur.action = 1;
        }
        else if(bossTrigger && mageFight)
        {
            mage.bossHasStarted = true;
            mage.SelectAction();
        }
        else if(!bossTrigger && mageFight)
        {
            mage.bossHasStarted = false;
            mage.action = 1;
        }

    }
}
