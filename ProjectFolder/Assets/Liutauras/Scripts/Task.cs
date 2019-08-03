using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public TaskData taskData;
    public float timeLeft;
    private bool completed = false;
   


    void Start(){
        timeLeft = taskData.baseTime;
     
    }
    void Update(){
        timeLeft -= Time.deltaTime;
    }

    public void CompleteTask(){
        Debug.Log("task completed");
        completed = true;
    }

    public bool isCompleted(){return completed;}

    void FailTask(){

    }

}
