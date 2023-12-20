using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStopStart : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameController.SINGLETON.startGameEvent.AddListener(StartMusic);
        GameController.SINGLETON.endGameEvent.AddListener(StopMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartMusic()
    {
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play(); 
    }

    void StopMusic()
    {
        GetComponent<AudioSource>().Stop();

    }
}
