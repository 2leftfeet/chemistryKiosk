using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public bool isTimedCanvas = false;
    public float screenTime;
    public GameObject targetScreen;

    private float startTime;
    void Start()
    {
        SetupCanvas();
    }
    void OnEnable()
    {
        SetupCanvas();
    }

    void Update()
    {
        if (isTimedCanvas)
        {
            while (Time.time < startTime + screenTime)
            {
                return;
            }

            if(targetScreen)
            {
                gameObject.SetActive(false);
                targetScreen.SetActive(true);
            }
        }
    }

    void SetupCanvas()
    {
        startTime = Time.time;
    }
}
