using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IHoldsIngredient
{
    bool AddIngredient(Ingredient toAdd);
    Ingredient RemoveIngredient();
    void SetUI(bool on);
}
