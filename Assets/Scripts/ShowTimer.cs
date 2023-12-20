using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = GameController.timeLeft;
        int seconds = ((int)time % 60);
        int minutes = ((int)time / 60);
        int hundreths = ((int)(time * 100f)) % 60;
        string timeStr = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, hundreths);
        GetComponent<TextMeshProUGUI>().SetText(timeStr);
    }
}
