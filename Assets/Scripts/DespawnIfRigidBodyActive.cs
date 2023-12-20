using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnIfRigidBodyActive : MonoBehaviour
{
    public GameObject spawnThisOnShatter;

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
        // play sound
        //Instantiate(spawnThisOnShatter, transform.parent.position, Quaternion.identity);

        print("Despawning");
        Destroy(gameObject);
        
        /*
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
