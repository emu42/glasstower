using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtRestSignal : MonoBehaviour
{
    private bool cameToRest = false;

    public GameObject piece;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!cameToRest)
        {

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f);
            if (hitColliders.Length == 0)
            {
                if (piece.GetComponent<Rigidbody>().velocity.magnitude <= 0.01)
                {
                    SendMessageUpwards("CameToRest", piece);
                    cameToRest = true;
                }

            }
        }
        
    }


}
