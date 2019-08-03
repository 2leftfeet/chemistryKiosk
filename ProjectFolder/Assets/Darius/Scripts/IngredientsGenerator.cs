using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsGenerator : MonoBehaviour
{
    const int ingredientCount = 5;

    const int correctIngredientCount = 3;

    static int correctIngredientsPresent = 0;

    List<Ingredient> needTaskIngredients = new List<Ingredient>();

    Ingredient[] currentIngredients;

    IngredientHolder allIngredients;

    private void Start()
    {
        currentIngredients = new Ingredient[ingredientCount];
    }


    public void AddIngredients(TaskData task)
    {
        for(int i = 0; i < task.neededIngredients.Count; i++)
        {
            if(!task.neededIngredients[i].craftable)
                needTaskIngredients.Add(task.neededIngredients[i]);
        }
    }


    private void Update()
    {
        if(currentIngredients.Length < ingredientCount)
        {
            
        }
    }


}
