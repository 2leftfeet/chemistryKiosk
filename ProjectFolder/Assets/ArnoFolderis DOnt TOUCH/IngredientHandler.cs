using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientHandler : MonoBehaviour
{
    [SerializeField]
    Ingredient ingredientDatainstance;
    [SerializeField]
    GameObject ingredientGO;

    [SerializeField]
    GameObject gasGO;
    [SerializeField]
    GameObject liquidGO;
    [SerializeField]
    GameObject solidGO;

    [SerializeField]
    Material coloredMat;
    [SerializeField]
    Material transMat;


    bool hasItem = false;

    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    void Start()
    {
        meshFilter = ingredientGO.GetComponent<MeshFilter>();

        meshRenderer = ingredientGO.GetComponent<MeshRenderer>();

        ChangeShape(ingredientDatainstance);
    }

    bool DEBUG = true;
    int DEBUG_CYCLING = 0;

    void Update()
    {


        if (DEBUG)
        {
            if (DEBUG_CYCLING > 200)
            {
                ChangeShape(ingredientDatainstance);
                DEBUG_CYCLING = 0;
            }
            DEBUG_CYCLING++;
        }

    }

    State state;
    // will change to ChangeShpare(Ingredient ingredientData)
    public void ChangeShape(Ingredient ingredientData)
    {
        if (ingredientData)
            hasItem = true;
        else
            hasItem = false;

        
           
            gasGO.SetActive(false);
            liquidGO.SetActive(false);
            solidGO.SetActive(false);
        if (hasItem)
        {

            coloredMat.color = ingredientData.color;
            // create object
            switch (ingredientData.state)
            {
                case State.Solid:
                    solidGO.SetActive(true);
                    break;
                case State.Liquid:
                    liquidGO.SetActive(true);
                    break;
                case State.Gas:
                    gasGO.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

}
