using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StationType
{
    HeatingPad,
    ElectrolysisStation,
    GasCollector,
    BuchnerFunnel,
    MuffleFurnace,
    SimpleTestTube,
    CoolingBath,
    HeatingLamp
}

public class Station : MonoBehaviour
{
    public RecipeHolder recipeHolder;

    public StationType stationType;    
    [SerializeField] private int slotCount = 2;

    public Ingredient[] ingredientSlots;
    

    void Start(){
        ingredientSlots = new Ingredient[slotCount];
    }

    void Update(){
        
    }

    

    public void AddIngredient(Ingredient ingredient){
        for(int i = 0; i < slotCount; i++){
            if(ingredientSlots[i] == null){
                ingredientSlots[i] = ingredient;
                break;
            }
        }
        RecipeCheck();
    }

    public Ingredient RemoveIngredient(){
        for(int i = slotCount; i >= 0; i--){
            if(ingredientSlots[i] != null){
                Ingredient toReturn = ingredientSlots[i];
                ingredientSlots[i] = null;
                return toReturn;
            }
        }
        RecipeCheck();
        return null;
    }

    [ContextMenu("Check for Recipe")]
    void RecipeCheck(){
        foreach(Recipe r in recipeHolder.allRecipes){
            bool recipeCorrect = true;
            if(r.stationToUse == stationType){
                Debug.Log("Testing recipe" + r.name);
                foreach(Ingredient ingredient in r.inputIngredients){
                    Debug.Log("Searching for ingredient" + ingredient.name);
                    bool contains = false;
                    for(int i = 0; i < slotCount; i++){
                        if(ingredientSlots[i] == ingredient){
                            contains = true;
                            Debug.Log("ingredient found");
                            break;
                        }
                    }
                    if(!contains){
                    recipeCorrect = false;
                    Debug.Log("ingredient not found");    
                    } 
                }
            }else{
                recipeCorrect = false;
            }
            if(recipeCorrect) ConvertIngredients(r);
        }
    }

    void ConvertIngredients(Recipe r){
        for(int i = 0; i < slotCount; i++){
            ingredientSlots[i] = null;
        }

        int j = 0;
        foreach(Ingredient ingredient in r.outputIngredients){
            ingredientSlots[j] = ingredient;
            j++;
        }
    }
    
}
