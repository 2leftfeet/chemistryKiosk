using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BubbleHandler : MonoBehaviour
{
    public Image mainImage;
    public Image secondaryImage;

    public Sprite liquid;
    public Sprite liquidSec;
    public Sprite solid;
    public Sprite solidSec;
    public Sprite gas;
    public Sprite gasSec;

    //public Ingredient ing;

    private State state;
    private Color ingColor;

    public TMP_Text formula;
    public void UpdateGUI(Ingredient ing)
    {
        if (!ing)
        {  
            mainImage.sprite = null;
            secondaryImage.sprite = null;
            secondaryImage.color = Color.white;
            formula.text = "Empty";
            Debug.Log("Empty");
            return;
        }
        formula.text = FormulaHandler.Convert(ing.id);
        state = ing.state;
        ingColor = ing.color;
        switch (state)
        {
            case State.Gas:
            {
                mainImage.sprite = gas;
                secondaryImage.sprite = gasSec;
                secondaryImage.color = ingColor;
                break;
            }
            case State.Liquid:
            { 
                mainImage.sprite = liquid;
                secondaryImage.sprite = liquidSec;
                secondaryImage.color = ingColor;
                break;
            }
            case State.Solid:
            {
                mainImage.sprite = solid;
                secondaryImage.sprite = solidSec;
                secondaryImage.color = ingColor;
                break;
            }
            default:
                break;
        }
    }
}
