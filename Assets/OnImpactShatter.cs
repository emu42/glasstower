using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpactShatter : MonoBehaviour
{
    private static float SHATTER_THRESHOLD = 1.5f;

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

        print("Collision detected with magnitude: " + velocity.magnitude);
        if (velocity.magnitude > SHATTER_THRESHOLD)
        {
            print("Die die die!!");
            GameController.SINGLETON.CollisionEnd();
            //SendMessageUpwards("CollisonEnd");
            Destroy(gameObject);

            // TODO: particles and shatter sound
        }
    }
}
