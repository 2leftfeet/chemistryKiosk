using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChemistryKiosk/Task Data")]
public class TaskData : ScriptableObject
{
    public List<Ingredient> neededIngredients;
    public Ingredient endProduct;
    public float baseTime;
    public GameObject customerPrefab;

}
