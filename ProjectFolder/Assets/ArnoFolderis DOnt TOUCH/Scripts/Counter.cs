using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour, IHoldsIngredient
{
    public BubbleHandler bubhan;
    public Ingredient ingredient;
    private IngredientHandler myIngredientHandler;
    [SerializeField] private int slotCount = 1;

    [SerializeField] bool conveyorCounter = false;
    [SerializeField] bool isInTheScene = false;

    void Start()
    {
        myIngredientHandler = gameObject.GetComponent<IngredientHandler>();
        if (ingredient) bubhan.UpdateGUI(ingredient);
    }

    public bool IsInScene()
    {
        return isInTheScene;
    }



    public bool AddIngredient(Ingredient _ingredient)
    {
        if (conveyorCounter)
            return false;
        bool added = false;
        
        for (int i = 0; i < slotCount; i++)
        {
            if (ingredient == null)
            {
                ingredient = _ingredient;
                added = true;
                isInTheScene = false;
                break;
            }
        }
        //add UI hook
        if(_ingredient) bubhan.UpdateGUI(_ingredient);
        //UpdateBubbles();
        myIngredientHandler.ChangeShape(ingredient);
        return added;
    }

    public bool GenerateIngredient(Ingredient _ingredient)
    {
        bool added = false;
        for (int i = 0; i < slotCount; i++)
        {
            if (ingredient == null)
            {
                ingredient = _ingredient;
                added = true;
                isInTheScene = false;
                break;
            }
        }
        //add UI hook
        if (_ingredient) bubhan.UpdateGUI(_ingredient);
        //UpdateBubbles();
        myIngredientHandler.ChangeShape(ingredient);
        return added;
    }

    public Ingredient RemoveIngredient()
    {
        for (int i = slotCount - 1; i >= 0; i--)
        {
            if (ingredient)
            {
                Ingredient toReturn = ingredient;
                ingredient = null;
                //add UI hook
                /*if (ingredient)*/ bubhan.UpdateGUI(ingredient);
                //UpdateBubbles();
                myIngredientHandler.ChangeShape(ingredient);
                return toReturn;
            }
        }
        //add UI hook
        /*if (ingredient)*/ bubhan.UpdateGUI(ingredient);
        //UpdateBubbles();
        myIngredientHandler.ChangeShape(ingredient);
        return null;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "SceneConveyor")
        {
            isInTheScene = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SceneConveyor")
        {
            isInTheScene = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SceneConveyor")
        {

        }
    }


}
