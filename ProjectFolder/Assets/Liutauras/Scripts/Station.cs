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
    HeatingLamp,
    PorousBedOfActivatedCarbon,
    GasInputter
}

public class Station : MonoBehaviour
{
    public RecipeHolder recipeHolder;

    public StationType stationType;    
    [SerializeField] private int slotCount = 2;

    public Ingredient[] ingredientSlots;

    //ROKO KODAS ATSARGIAI
    public BubbleHandler BubHan1;
    public BubbleHandler BubHan2;
    //ROKO KODAS BAIGIASI PHEW


    void Start(){
        ingredientSlots = new Ingredient[slotCount];
    }

    void Update(){
        
    }

    

    public bool AddIngredient(Ingredient ingredient){
        bool added = false;
        for(int i = 0; i < slotCount; i++){
            if(ingredientSlots[i] == null){
                ingredientSlots[i] = ingredient;
                added = true;
                break;
            }
        }
        RecipeCheck();
        BubHan1.UpdateGUI(ingredientSlots[0]); //ROKO KODAS
        BubHan2.UpdateGUI(ingredientSlots[1]); //ROKO KODAS
        return added;
    }

    public Ingredient RemoveIngredient(){
        for(int i = slotCount -1; i >= 0; i--){
            if(ingredientSlots[i]){
                Ingredient toReturn = ingredientSlots[i];
                ingredientSlots[i] = null;
                return toReturn;
            }
        }
        RecipeCheck();
        BubHan1.UpdateGUI(ingredientSlots[0]);
        BubHan2.UpdateGUI(ingredientSlots[1]);//ROKO KODAS
        return null;
    }

    [ContextMenu("Check for Recipe")]
    void RecipeCheck() { 
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
