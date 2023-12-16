using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpactShatter : MonoBehaviour
{
    private static float SHATTER_THRESHOLD = 10f;

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
        Vector3 velocity = collision.relativeVelocity;

        if (velocity.magnitude > SHATTER_THRESHOLD)
        {
            print("Die die die!!");
            SendMessageUpwards("CollisonEnd");
        }
    }
}
