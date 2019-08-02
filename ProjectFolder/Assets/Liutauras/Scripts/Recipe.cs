using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChemistryKiosk/Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField]
    List<Ingredient> inputIngredients;

    [SerializeField]
    List<Ingredient> outputIngredients;

    public StationType stationToUse;

}
