using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChemistryKiosk/RecipeHolder")]
public class RecipeHolder : ScriptableObject
{
   [SerializeField]
   public List<Recipe> allRecipes;
}
