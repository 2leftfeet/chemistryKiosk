using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCreator : MonoBehaviour
{
    public TaskHolder availableTasks;

    private List<Task> currentTasks;

    public float minWaitTime = 20.0f;
    public float maxWaitTime = 30.0f;
    private float waiter;

    void Start()
    {
        while(waiter > 0.0f){
            waiter -= Time.deltaTime;
        }
        if(waiter <= 0.0f){
            CreateTask();
            waiter = Random.Range(minWaitTime, maxWaitTime);
        }
    }

    void CreateTask(){
        int taskIdx = Random.Range(0, availableTasks.tasks.Count);
        TaskData toCreate = availableTasks.tasks[taskIdx];
        GameObject newTask = new GameObject();
        Task addedTask = newTask.AddComponent<Task>();
        addedTask.taskData = toCreate;
        newTask.transform.parent = this.gameObject.transform;
        currentTasks.Add(addedTask);
    }
}
