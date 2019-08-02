using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StationType{
    KippsApparatus,
    Distilator,
    HeatingPad,
    ElectrolysisStation,
    GasLamp,
    GasCollector,
    Mixer,
    BuchnerFunnel,
    MuffleFurnace
}

public class Station : MonoBehaviour
{
    private StationType stationType;    
    [SerializeField] private int inputSlotCount = 2;
    [SerializeField] private int outputSlotCount = 2;

    private Ingredient[] inputIngredients;
    private Ingredient[] outputIngredients;

    void Start(){
        inputIngredients = new Ingredient[inputSlotCount];
        outputIngredients = new Ingredient[outputSlotCount];
    }
    
}
