using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().SetText("Height reached:\n" + GameController.heightReached);
    }
}
