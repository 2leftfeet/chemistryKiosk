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
    GasInputter,
    ConicalFlask,
    Counter
}

public class Station : MonoBehaviour, IHoldsIngredient
{
    public RecipeHolder recipeHolder;

    public StationType stationType;
    [SerializeField] private int slotCount = 2;

    public Ingredient[] ingredientSlots;

    //ROKO KODAS ATSARGIAI
    public BubbleHandler BubHan1;
    public BubbleHandler BubHan2;
    //ROKO KODAS BAIGIASI PHEW


    void Start() {
        ingredientSlots = new Ingredient[slotCount];
    }

    void Update() {

    }



    public bool AddIngredient(Ingredient ingredient) {
        bool added = false;
        for (int i = 0; i < slotCount; i++) {
            if (ingredientSlots[i] == null) {
                ingredientSlots[i] = ingredient;
                added = true;
                break;
            }
        }
        RecipeCheck();
        UpdateBubbles();
        return added;
    }

    public Ingredient RemoveIngredient() {
        for (int i = slotCount - 1; i >= 0; i--) {
            if (ingredientSlots[i]) {
                Ingredient toReturn = ingredientSlots[i];
                ingredientSlots[i] = null;
                UpdateBubbles();
                return toReturn;
            }
        }
        RecipeCheck();
        UpdateBubbles();
        return null;
    }

    [ContextMenu("Check for Recipe")]
    void RecipeCheck() {
        foreach (Recipe r in recipeHolder.allRecipes) {
            bool recipeCorrect = true;
            if (r.stationToUse == stationType) {
                foreach (Ingredient ingredient in r.inputIngredients) {
                    bool contains = false;
                    for (int i = 0; i < slotCount; i++) {
                        if (ingredientSlots[i] == ingredient) {
                            contains = true;
                            break;
                        }
                    }
                    if (!contains) {
                        recipeCorrect = false;
                    }
                }
            } else {
                recipeCorrect = false;
            }
            if (recipeCorrect) ConvertIngredients(r);
        }
    }

    void ConvertIngredients(Recipe r) {
        for (int i = 0; i < slotCount; i++) {
            ingredientSlots[i] = null;
        }

        int j = 0;
        foreach (Ingredient ingredient in r.outputIngredients) {
            ingredientSlots[j] = ingredient;
            j++;
        }
    }

    private void UpdateBubbles()
    {
        if (BubHan1)
            BubHan1.UpdateGUI(ingredientSlots[0]);
        if (BubHan2)
            BubHan2.UpdateGUI(ingredientSlots[1]);
    }
}
