using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExitSpawn : MonoBehaviour
{
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        spawner.SendMessage("PrepareNext");
    }
}
