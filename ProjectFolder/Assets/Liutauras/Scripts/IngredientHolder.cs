using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChemistryKiosk/IngredientHolder")]
public class IngredientHolder : ScriptableObject
{
    [SerializeField]
    public List<Ingredient> ingredients;
}
