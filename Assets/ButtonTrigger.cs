using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Triggered button");
        AudioSource audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        SendMessageUpwards("TriggerEnter");
    }
}
