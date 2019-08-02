using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChemistryKiosk/Task Data Holder")]
public class TaskHolder : ScriptableObject
{
    
    [SerializeField] public List<TaskData> tasks;
}
