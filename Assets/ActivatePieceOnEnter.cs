using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePieceOnEnter : MonoBehaviour
{
    public GameObject newPiece;

    public GameObject prefab;

    private bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
        print("Registering spawner reset");
        GameController.SINGLETON.startGameEvent.AddListener(StartGame);
        GameController.SINGLETON.endGameEvent.AddListener(EndGame);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        ready = true;
        PrepareNext();
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
        print("PrepareNext called");
        if (newPiece == null && ready)
        {
            print("spawning new piece");
            newPiece = Instantiate(prefab, transform.parent);
            newPiece.GetComponentInChildren<Rigidbody>().isKinematic = true;
            //newPiece.SetActive(true);
        }
    }
}
