using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngridientSlider : MonoBehaviour
{
    public Slider Timer;

    private float time;
    public float timeToComplete; // Base Time

    public Gradient grad;
    public Image image;
    void Start()
    {
        time = 0;
        Timer.maxValue = timeToComplete;
        Timer.value = 0;
    }
    void Update()
    {
        time += Time.deltaTime;
        Timer.value = time;

        image.color = grad.Evaluate(time / timeToComplete);

        if (Timer.value == timeToComplete)
        {
            IngridientFinish();
        }
    }

    void IngridientFinish()
    {
        Debug.Log("Finish");
        Destroy(this.gameObject);
    }
}
