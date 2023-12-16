using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private static float timeLeftMillis;

    private static bool gameStopped = true;

    private static float heightReached = 0f;

    public GameObject towerBase;

    public static GameObject FindController()
    {
        return GameObject.Find("Root");
    }

    public void CollisionEnd()
    {
        gameStopped = true;

        BroadcastMessage("EndGame");
    }

    private void TimeEnd()
    {
        gameStopped = true;

        BroadcastMessage("EndGame");
    }

    public void GameStart()
    {
        timeLeftMillis = 30000f;
        gameStopped = false;
        heightReached = 0f;

        BroadcastMessage("StartGame");
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
            timeLeftMillis -= Mathf.Max(Time.deltaTime, 0f);
            if (timeLeftMillis == 0f)
            {
                TimeEnd();
            }
        }
    }

    void CameToRest(Rigidbody piece)
    {
        float baseY = towerBase.transform.position.y;
        heightReached = Mathf.Max(piece.position.y - baseY, heightReached);
    }
}
