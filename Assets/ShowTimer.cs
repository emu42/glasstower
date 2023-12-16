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
        print("Updating timer display: " + GameController.timeLeftMillis);
        GetComponent<TextMeshPro>().SetText("" + GameController.timeLeftMillis);
    }
}
