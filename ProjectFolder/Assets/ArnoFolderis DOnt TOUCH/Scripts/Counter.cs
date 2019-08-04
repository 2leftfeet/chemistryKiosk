using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour, IHoldsIngredient
{
    public BubbleHandler bubhan;
    public Ingredient ingredient;
    private IngredientHandler myIngredientHandler;
    [SerializeField] private int slotCount = 1;

    [SerializeField] bool conveyorCounter = false;
    [SerializeField] bool isInTheScene = false;
    private LayerMask playerMask;
    public float showRadius = 3.0f;

    void Start()
    {
        myIngredientHandler = gameObject.GetComponent<IngredientHandler>();
        if (ingredient) bubhan.UpdateGUI(ingredient);
        playerMask = LayerMask.GetMask("Players");
        showRadius = 3.0f;
    }

    public bool IsInScene()
    {
        return isInTheScene;
    }

    void Update(){
        if(ingredient){
            Collider[] playerCollisions = Physics.OverlapSphere(transform.position, showRadius, playerMask);

            if(playerCollisions.Length == 0){
                bubhan.gameObject.SetActive(false);
            }
            else{
                bubhan.gameObject.SetActive(true);
            }
        }else{
            bubhan.gameObject.SetActive(false);
        }
    }



    public bool AddIngredient(Ingredient _ingredient)
    {
        if (conveyorCounter)
            return false;
        bool added = false;
        
        for (int i = 0; i < slotCount; i++)
        {
            if (ingredient == null)
            {
                ingredient = _ingredient;
                added = true;
                isInTheScene = false;
                if (_ingredient) bubhan.UpdateGUI(_ingredient);
                break;
            }
        }
        //add UI hook
        
        //UpdateBubbles();
        myIngredientHandler.ChangeShape(ingredient);
        return added;
    }

    public bool GenerateIngredient(Ingredient _ingredient)
    {
        bool added = false;
        for (int i = 0; i < slotCount; i++)
        {
            if (ingredient == null)
            {
                ingredient = _ingredient;
                added = true;
                isInTheScene = false;
                if (bubhan) bubhan.UpdateGUI(ingredient);
                break;
            }
        }
        //add UI hook
        /*if (_ingredient)*/ 
        //UpdateBubbles();
        myIngredientHandler.ChangeShape(ingredient);
        return added;
    }

    public Ingredient RemoveIngredient()
    {
        for (int i = slotCount - 1; i >= 0; i--)
        {
            if (ingredient)
            {
                Ingredient toReturn = ingredient;
                ingredient = null;
                //add UI hook
                /*if (ingredient)*/ if(bubhan) bubhan.UpdateGUI(ingredient);
                //UpdateBubbles();
                myIngredientHandler.ChangeShape(ingredient);
                return toReturn;
            }
        }
        //add UI hook
        if (ingredient) bubhan.UpdateGUI(ingredient);
        //UpdateBubbles();
        myIngredientHandler.ChangeShape(ingredient);
        return null;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "SceneConveyor")
        {
            isInTheScene = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SceneConveyor")
        {
            isInTheScene = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SceneConveyor")
        {

        }
    }


}
