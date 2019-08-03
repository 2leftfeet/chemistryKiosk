using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsGenerator : MonoBehaviour
{
    struct ConveyorIngredients
    {
        public Ingredient ingredient;
        public bool isPresent;
    }


    //const int ingredientCount = 5;

    //const int correctIngredientCount = 3;

    //static int correctIngredientsPresent = 0;

    List<Ingredient> needTaskIngredients = new List<Ingredient>();

    //List<Ingredient> currentIngredients = new List<Ingredient>();

    //IngredientHolder allIngredients;

    //List<Ingredient> uncraftableIngredients = new List<Ingredient>();


    List<ConveyorIngredients> neededIngredients = new List<ConveyorIngredients>();


    private void Start()
    {
        /*uncraftableIngredients = new List<Ingredient>();

        foreach(Ingredient ing in allIngredients.ingredients)
        {
            if(!ing.craftable)
            {
                uncraftableIngredients.Add(ing);
            }
        }*/
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
        /*if(currentIngredients.Count < ingredientCount)
        {
            if(correctIngredientsPresent < correctIngredientCount)
            {               
                 foreach(Ingredient ing in needTaskIngredients)
                 {
                      if(ing != null)
                      {
                          currentIngredients.Add(ing);
                          needTaskIngredients.Remove(ing);
                          correctIngredientsPresent++;
                      }
                 }
                    
                
            }
            else
            {            
                int randomElement = Random.Range(0, uncraftableIngredients.Count);
                currentIngredients.Add(uncraftableIngredients[randomElement]);                    
                
            }
        }*/

        for(int i = 0; i < needTaskIngredients.Count; i++)
        {
            bool addToConveyor = true;
            for (int a = 0; a < neededIngredients.Count; a++)
            {
                addToConveyor = false;
                break;
            }
            if(addToConveyor)
            {
                ConveyorIngredients addedIngredient;
                addedIngredient.ingredient = needTaskIngredients[i];
                addedIngredient.isPresent = true;
            }
        }

    }


}
