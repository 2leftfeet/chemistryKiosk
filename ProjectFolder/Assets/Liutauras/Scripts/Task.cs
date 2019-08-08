using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Completion
{
    InProgress,
    Completed,
    Failed
}

public class Task : MonoBehaviour
{
    public TaskData taskData;
    public float timeLeft;
    public TaskCreator taskCreator;
    private Completion completion; 
   


    void Start(){
        timeLeft = taskData.baseTime;
        completion = Completion.InProgress;
     
    }
    void Update(){
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0.0f)
        {
            FailTask();
        }
    }

    public void CompleteTask(){
        Debug.Log("task completed");
        completion = Completion.Completed;
        
    }

    public Completion getCompletion(){return completion;}

    void FailTask(){
        completion = Completion.Failed;
    }

}
