using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FormulaHandler
{
    public static string Convert(string formula)
    {
        string result = formula;

        result = result.Replace("_", "<sub>");
        result = result.Replace("-", "</sub>");
        
        return result;
    }
}
