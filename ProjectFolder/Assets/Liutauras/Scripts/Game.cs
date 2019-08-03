using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    int playerCount;

    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    Transform[] spawn;

    void Start(){
        for (int i = 1; i <= playerCount; i++)
        {
            GameObject go = Instantiate(playerPrefab);
            go.GetComponent<MovementController>().SetPlayerNumber(i);
            go.transform.position = spawn[i-1].position;
        }
    }

    
}
