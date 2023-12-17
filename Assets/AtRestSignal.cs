using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtRestSignal : MonoBehaviour
{
    private bool cameToRest = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!cameToRest && gameObject.activeSelf)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            if (!rb.isKinematic) { 
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.0f, 1 << 7);  // check on proximity layer
                print("num colliders " + hitColliders.Length);
                if (hitColliders.Length == 0 && rb.velocity.magnitude <= 0.01)
                {
                    print("zero movement");
                    GameController.SINGLETON.CameToRest(gameObject);
                    //SendMessageUpwards("CameToRest", piece);
                    print("Piece came to rest");
                    cameToRest = true;

                }
            }
        }
    }
}
