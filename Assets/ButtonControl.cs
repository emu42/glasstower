using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private bool primed = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerRelease()
    {
        primed = true;
    }

    public void TriggerEnter()
    {
        print("ButtonControl.TriggerEnter");
        if (primed)
        {
            SendMessageUpwards("GameStartButtonPressed");
            primed = false;
        }
    }
}
