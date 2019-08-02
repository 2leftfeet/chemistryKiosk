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

}
