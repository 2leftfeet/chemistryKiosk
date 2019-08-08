﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    int StartingScore = 500;
    int totalScore;
    int totalLives;
    bool countingScore = false;

    [SerializeField]
    bool[] activePlayers = { false };

    private int playerCount = 4;

    [SerializeField]
    GameObject[] playerPrefab;

    [SerializeField]
    Transform[] spawn;

    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    TMP_Text livesText;

    [SerializeField]
    GameObject endScreen;

    public static Game instance;

    bool endedd;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    void Start(){

        DontDestroyOnLoad(this.gameObject);
        totalScore = 0;
        totalLives = 5;
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
        //totalScore = StartingScore;
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
        livesText = GameObject.FindGameObjectWithTag("LivesText").GetComponent<TMP_Text>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TMP_Text>();
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        scoreText.text = "SCORE: " + totalScore.ToString();
    }

    [ContextMenu("Remove One Life")]
    public void RemoveLife()
    {
        totalLives--;
        livesText.text = "LIVES: " + totalLives.ToString();
        if(totalLives <= 0)
        {
            EndGame();
        }
    }

    public float amountOfTimeYouCannotDoStuffWhenYouDie = 1.0f;
    

    void FixedUpdate()
    {
         if(amountOfTimeYouCannotDoStuffWhenYouDie > 0)
           {
            amountOfTimeYouCannotDoStuffWhenYouDie -=  0.02f;
           }
    }

    private void Update()
    {
        if (ranOnce)
        {
            if (Input.anyKey && amountOfTimeYouCannotDoStuffWhenYouDie <= 0)
            {
                SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
                Destroy(this.gameObject);
            }
        }

    }

    bool ranOnce = false;

    [SerializeField] TMP_Text[] 死後沈黙する時;

    void EndGame()
    {
        if (!ranOnce)
        {
            ranOnce = true;
            GameObject _endScreen = Instantiate(endScreen);
           ;
            if (_endScreen)
            {
                死後沈黙する時 = _endScreen.GetComponentsInChildren<TMP_Text>();
                死後沈黙する時[2].text += (" " + totalScore);
            }
        }
    }



    
}
