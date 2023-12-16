using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnIfRigidBodyActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void Awake()
    {
        GameController.SINGLETON.startGameEvent.AddListener(StartGame);
    }

    public void StartGame()
    {
        if (!GetComponentInChildren<Rigidbody>().isKinematic)
        {
            GameController.SINGLETON.startGameEvent.RemoveListener(StartGame);
            Destroy(this);
        }
    }

    public void EndGame()
    {

    }
}
