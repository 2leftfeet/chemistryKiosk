using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngridientSlider : MonoBehaviour
{
    public Slider Timer;

    public Gradient grad;
    public Image image;
    void Start()
    {
        Timer.value = 0;
    }
   
    public void SetValue(float t, float maxTime){
        Timer.value = t;
        Timer.maxValue = maxTime;
        image.color = grad.Evaluate(t /maxTime);
    }

}
