using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnIfRigidBodyActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Registering with singleton for cleanup");
        GameController.SINGLETON.startGameEvent.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void Awake()
    {
    }

    void StartGame()
    {
        print("Despawning");
        Destroy(gameObject);/*
        if (!GetComponentInChildren<Rigidbody>().isKinematic)
        {
            GameController.SINGLETON.startGameEvent.RemoveListener(StartGame);
            Destroy(this);
        }*/
    }

    public void EndGame()
    {

    }
}
