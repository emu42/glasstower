using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePieceOnEnter : MonoBehaviour
{
    public GameObject newPiece;

    public GameObject prefab;

    private bool ready = true;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        ready = true;
        newPiece = Instantiate(prefab, transform.parent);
        newPiece.SetActive(true);
    }

    public void EndGame()
    {
        ready = false;
        Destroy(newPiece);
        newPiece = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("triggered on enter");
        if (newPiece != null && ready)
        {
            print("activated piece");
            newPiece.GetComponentInChildren<Rigidbody>().isKinematic = false;
            newPiece = null;
        }
    }

    private void PrepareNext()
    {
        if (newPiece == null && ready)
        {
            print("spawning new piece");
            newPiece = Instantiate(prefab, transform.parent);
            newPiece.GetComponentInChildren<Rigidbody>().isKinematic = true;
            newPiece.SetActive(true);
        }
    }
}
