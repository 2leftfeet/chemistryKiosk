using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputBox : MonoBehaviour, IHoldsIngredient
{

    public Task currentTask;
    public Ingredient placedIngredient;
    
    public OrderPopup orderPopup;

    public bool AddIngredient(Ingredient toAdd){
        if(!placedIngredient){
            placedIngredient = toAdd;
        }else{
            return false;
        }
        if(currentTask){
            if(placedIngredient == currentTask.taskData.endProduct){
                currentTask.CompleteTask();
                currentTask = null;
                placedIngredient = null;
                orderPopup.gameObject.SetActive(false);
            }
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
        orderPopup.gameObject.SetActive(true);
        orderPopup.NewTask(task);
    }
}
