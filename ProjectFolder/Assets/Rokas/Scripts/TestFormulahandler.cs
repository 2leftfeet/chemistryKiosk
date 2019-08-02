using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestFormulahandler : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = FormulaHandler.Convert("(NH_2-)_2-CO");
    }
}
