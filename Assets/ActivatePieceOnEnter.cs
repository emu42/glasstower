using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class ActivatePieceOnEnter : MonoBehaviour
{
    public GameObject inactivePiece;

    private GameObject prefab;


    // Start is called before the first frame update
    void Start()
    {
        prefab = inactivePiece;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("triggered on enter");
        if (inactivePiece != null)
        {
            print("activated piece");
            inactivePiece.GetComponentInChildren<Rigidbody>().isKinematic = false;
            inactivePiece = null;
        }
    }

    private void PrepareNext()
    {
        if (inactivePiece == null)
        {
            print("spawning new piece");
            inactivePiece = Instantiate(prefab, transform.position, Quaternion.identity);
            inactivePiece.GetComponentInChildren<Rigidbody>().isKinematic = true;
        }
    }
}
