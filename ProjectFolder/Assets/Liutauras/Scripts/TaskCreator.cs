using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCreator : MonoBehaviour
{
    public TaskHolder availableTasks;
    public IngredientsGenerator ingredientsGenerator;

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

        CheckTasks();
    }

    void CreateTask(){
        //Increase current task count
        currentTaskCount++;
        //Choose a random task from task list
        int taskIdx = Random.Range(0, availableTasks.tasks.Count);
        TaskData toCreate = availableTasks.tasks[taskIdx];
        //Create a Gameobject for the task, add the task component and give it the task data
        GameObject newTask = new GameObject();
        newTask.name = toCreate.name;
        Task addedTask = newTask.AddComponent<Task>();
        addedTask.taskData = toCreate;
        //parent the component under task creator
        newTask.transform.parent = this.gameObject.transform;
        //keep track of the task
        for(int i = 0; i < 3; i++){
            if(currentTasks[i]) continue;
            else {
                currentTasks[i] = addedTask;
                outputBoxes[i].AddTask(addedTask);
                break;
            }
        }
        if(ingredientsGenerator) ingredientsGenerator.AddIngredients(toCreate);

    }

    void CheckTasks(){
        for(int i = 0; i < 3; i++){
            if(currentTasks[i]){
                Completion com = currentTasks[i].getCompletion();
                if(com != Completion.InProgress){
                    EndTask(i, com);
                }
            }
        }
    }

    void EndTask(int i, Completion completion){

        switch (completion)
        {
            case Completion.Completed:
                Game.instance.AddScore((int)currentTasks[i].timeLeft);
                break;
            case Completion.Failed:
                Game.instance.RemoveLife();
                break;
            default:
                break;
        }
        
        ingredientsGenerator.RemoveIngredients(currentTasks[i].taskData);
        currentTaskCount--;
        Destroy(currentTasks[i].gameObject);
        currentTasks[i] = null;
    }
}
