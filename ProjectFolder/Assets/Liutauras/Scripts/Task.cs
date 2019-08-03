using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public TaskData taskData;
    private float timeLeft;
   


    void Start(){
        timeLeft = taskData.baseTime;
        toMake = taskData.endProduct;
    }
    void Update(){
        timeLeft -= Time.deltaTime;
    }

    public void CompleteTask(){

    }

    void FailTask(){

    }

}
