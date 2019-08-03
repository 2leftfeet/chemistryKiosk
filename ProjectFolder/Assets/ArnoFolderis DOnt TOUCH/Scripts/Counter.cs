using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour, IHoldsIngredient
{

    public Ingredient ingredient;
    private IngredientHandler myIngredientHandler;
    [SerializeField] private int slotCount = 1;

    void Start()
    {
        myIngredientHandler = gameObject.GetComponent<IngredientHandler>();
    }

    public bool AddIngredient(Ingredient _ingredient)
    {
        bool added = false;
        for (int i = 0; i < slotCount; i++)
        {
            if (ingredient == null)
            {
                ingredient = _ingredient;
                added = true;
                break;
            }
        }
        //add UI hook
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
                //UpdateBubbles();
                myIngredientHandler.ChangeShape(ingredient);
                return toReturn;
            }
        }
        //add UI hook
        //UpdateBubbles();
        myIngredientHandler.ChangeShape(ingredient);
        return null;
    }
}
