using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientHandler : MonoBehaviour
{
    [SerializeField]
    Ingredient ingredientDatainstance;

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

    [SerializeField]
    MeshRenderer[] renderer;

    private MaterialPropertyBlock _propBlock;
    void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
    }

    void Start()
    {



        ChangeShape(ingredientDatainstance);
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
            
            // create object
            switch (ingredientData.state)
            {
                case State.Solid:
                    solidGO.SetActive(true);
                    renderer[0].GetPropertyBlock(_propBlock);
                    _propBlock.SetColor("_Color", ingredientData.color);
                    renderer[0].SetPropertyBlock(_propBlock);
                    break;
                case State.Liquid:
                    liquidGO.SetActive(true);
                    renderer[1].GetPropertyBlock(_propBlock);
                    _propBlock.SetColor("_Color", ingredientData.color);
                    renderer[1].SetPropertyBlock(_propBlock);
                    break;
                case State.Gas:
                    gasGO.SetActive(true);
                    renderer[2].GetPropertyBlock(_propBlock);
                    _propBlock.SetColor("_Color", ingredientData.color);
                    renderer[2].SetPropertyBlock(_propBlock);
                    break;
                default:
                    break;
            }
        }
    }

}
