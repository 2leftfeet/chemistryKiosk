using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputBox : MonoBehaviour, IHoldsIngredient
{

    public Task currentTask;
    public Ingredient placedIngredient;
    // Start is called before the first frame update

    // Update is called once per frame

    public bool AddIngredient(Ingredient toAdd){
        if(!placedIngredient){
            placedIngredient = toAdd;
        }else{
            return false;
        }
        if(placedIngredient == currentTask.taskData.endProduct){
            currentTask.CompleteTask();
        }
        return true;
    }

    public Ingredient RemoveIngredient(){
        Ingredient toReturn = placedIngredient;
        placedIngredient = null;
        return toReturn;
    }

    public void AddTask(Task task){
        currentTask = task; 
    }
}
