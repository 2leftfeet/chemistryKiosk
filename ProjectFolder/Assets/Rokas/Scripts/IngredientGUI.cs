using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientGUI : MonoBehaviour
{
    public Image mainImage;
    public Image secondaryImage;

    public Sprite liquid;
    public Sprite liquidSec;
    public Sprite solid;
    public Sprite solidSec;
    public Sprite gas;
    public Sprite gasSec;


    private State state;
    private Color ingColor;

    public TMP_Text formula;
    public void UpdateGUI(Ingredient slot1, Ingredient slot2)
    {
        Debug.Log("UpdateGUI");

    }

    private void UpdateSlotOne(Ingredient slot1)
    {
        state = slot1.state;
        ingColor = slot1.color;
        formula.text = FormulaHandler.Convert(slot1.id);

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
                //Empty
                break;
        }
    }

    private void UpdateSlotTwo(Ingredient slot2)
    {
        state = slot2.state;
        ingColor = slot2.color;
        formula.text = FormulaHandler.Convert(slot2.id);

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
                //Empty
                break;
        }
    }
}
