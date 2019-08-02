using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    [SerializeField]
    List<Ingredient> inputIngredients;

    [SerializeField]
    List<Ingredient> outputIngredients;

}
