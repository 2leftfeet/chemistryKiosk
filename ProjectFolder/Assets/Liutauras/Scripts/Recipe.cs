using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChemistryKiosk/Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField]
    public List<Ingredient> inputIngredients;

    [SerializeField]
    public List<Ingredient> outputIngredients;

    public StationType stationToUse;

}
