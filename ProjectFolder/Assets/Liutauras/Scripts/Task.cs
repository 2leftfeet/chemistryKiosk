using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public TaskData taskData;
    private float timeLeft;
    private Ingredient toMake;


    void Start(){
        timeLeft = taskData.baseTime;
        toMake = taskData.endProduct;
    }
    void Update(){
        timeLeft -= Time.deltaTime;
    }

}
