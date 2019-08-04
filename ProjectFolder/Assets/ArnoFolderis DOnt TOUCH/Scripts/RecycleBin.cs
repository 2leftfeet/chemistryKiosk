using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBin : MonoBehaviour, IHoldsIngredient
{
    public bool AddIngredient(Ingredient _ingredient)
    {
        return true;
    }

    public Ingredient RemoveIngredient()
    {
        return null;
    }
}
