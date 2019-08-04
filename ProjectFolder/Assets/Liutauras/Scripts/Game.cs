using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    int StartingScore = 500;
    [SerializeField] int totalScore;
    bool countingScore = false;

    [SerializeField]
    bool[] activePlayers = { false };

    private int playerCount = 4;

    [SerializeField]
    GameObject[] playerPrefab;

    [SerializeField]
    Transform[] spawn;

    void Start(){

        DontDestroyOnLoad(this.gameObject);
        // for debuging
        //activePlayers = new bool[4];
        //activePlayers[0] = true;
       // activePlayers[1] = true;
        //activePlayers[2] = true;
        //activePlayers[3] = true;
        //StartGame(activePlayers);
    }


    public void StartGame(bool[] players)
    {
        totalScore = StartingScore;
        countingScore = true;
        GameObject[] spawngos = GameObject.FindGameObjectsWithTag("SpawnPoint");
        // had coding playercount
        for (int i = 0; i < playerCount; i++)
        {
            if (players[i])
            {
                GameObject go = Instantiate(playerPrefab[i]);
                go.GetComponent<MovementController>().SetPlayerNumber(i);
                if(spawngos[i])
                    go.transform.position = spawngos[i].transform.position;
            }
        }
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
    }

    int temp = 0;

    void FixedUpdate()
    {
        if(temp > 100)
        {
            temp = 0;
            AddScore(-1);
        }
        temp++;
    }



    
}
