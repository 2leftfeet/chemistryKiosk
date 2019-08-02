using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YourSlider : MonoBehaviour
{
    public Slider Timer;

    public GameObject NpcType;
    public TMP_Text NpcName;

    private float time;
    public float MaxTime; // Base Time

    public Gradient grad;
    public Image image;
    void Start()
    {

        NpcName.text = NpcType.name;
        time = MaxTime;
        //Timer = GetComponent<Slider>();
        Timer.maxValue = MaxTime;
        Timer.value = time;
    }
    void Update()
    {
        time -= Time.deltaTime;
        Timer.value = time;

        image.color = grad.Evaluate(time/MaxTime);

        if (Timer.value == 0)
        {
            OrderFail();
        }
    }

    void OrderFail()
    {
        Debug.Log("Failed Order");
        Destroy(this.gameObject);
    }
}
