using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCreator : MonoBehaviour
{
    public TaskHolder availableTasks;

    private int currentTaskCount = 0;
    public Task[] currentTasks;
    public OutputBox[] outputBoxes;

    public float minWaitTime = 20.0f;
    public float maxWaitTime = 30.0f;
    private float waiter;

    void Start()
    {
        currentTasks = new Task[3];
        
    }

    void Update()
    {
        if(waiter > 0.0f){
            waiter -= Time.deltaTime;
        }
        if(waiter <= 0.0f){
            waiter = Random.Range(minWaitTime, maxWaitTime);
            if(currentTaskCount < 3){
                CreateTask();
            }
        }
    }

    void CreateTask(){
        int taskIdx = Random.Range(0, availableTasks.tasks.Count);
        TaskData toCreate = availableTasks.tasks[taskIdx];
        GameObject newTask = new GameObject();
        Task addedTask = newTask.AddComponent<Task>();
        addedTask.taskData = toCreate;
        newTask.transform.parent = this.gameObject.transform;
        for(int i = 0; i < 3; i++){
            if(currentTasks[i]) continue;
            else currentTasks[i] = addedTask;
        }


    }
}
