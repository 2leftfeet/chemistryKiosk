using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderPopup : MonoBehaviour
{
    public Slider Timer;

    public GameObject NpcType;
    public TMP_Text NpcName;
    public TMP_Text orderIngredient;

    public Gradient grad;
    public Image image;
    private Task currentTask;


    
    void Update()
    {
        if(currentTask) {
            Timer.value = currentTask.timeLeft;
            UpdatePopup(currentTask.timeLeft, currentTask.taskData.baseTime);
        }
    }

    public void NewTask(Task task){
        orderIngredient.text = FormulaHandler.Convert(task.taskData.endProduct.id);
        Timer.maxValue = task.taskData.baseTime;
        currentTask = task;
    }
    void UpdatePopup(float currentTime, float maxTime)
    {
        image.color = grad.Evaluate(currentTime/maxTime);
        NpcName.text = currentTask.taskData.npcName;

    }
}
