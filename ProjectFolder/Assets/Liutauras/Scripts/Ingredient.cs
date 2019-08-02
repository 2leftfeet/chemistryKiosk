using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State{
    Solid,
    Liquid,
    Gas
}

public enum Concentration{
    High,
    Medium,
    Low,
    None
}

[CreateAssetMenu]
public class Ingredient : ScriptableObject
{
    public string name;
    public Color color;
    public Concentration concentration;
    public State state;

}
