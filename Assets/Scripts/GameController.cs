using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    public static float timeLeft;

    private static bool gameStopped = true;

    public static float heightReached = 0f;

    public GameObject towerBase;

    public UnityEvent startGameEvent { get; private set; } = new();

    public UnityEvent endGameEvent { get; private set; } = new();

    public static GameController SINGLETON { get; private set; }

    public void Awake()
    {
        SINGLETON = this;
        print("GameController singleton initialized");
    }
    public static GameObject FindController()
    {
        return GameObject.Find("Root");
    }

    public void CollisionEnd()
    {
        print("collision game over triggered");
        gameStopped = true;

        //BroadcastMessage("EndGame");
        endGameEvent.Invoke();
    }

    private void TimeEnd()
    {
        gameStopped = true;

        //BroadcastMessage("EndGame");
        endGameEvent.Invoke();
    }

    public void GameStart()
    {
        print("Starting game");
        timeLeft = 10f;
        gameStopped = false;
        heightReached = 0f;

        startGameEvent.Invoke();
        //BroadcastMessage("StartGame");
        print("Sent start message");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameStopped)
        {
            timeLeft = Mathf.Max(timeLeft - Time.deltaTime, 0f);
            if (timeLeft == 0f)
            {
                TimeEnd();
            }
        }
    }

    public void CameToRest(GameObject piece)
    {
        float baseY = towerBase.transform.position.y;
        float pieceY = piece.GetComponent<BoxCollider>().bounds.max.y; 
        heightReached = Mathf.Max(pieceY - baseY, heightReached);
        
    }

    public void GameStartButtonPressed()
    {
        GameStart();
    }
}
