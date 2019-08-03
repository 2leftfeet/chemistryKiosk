using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    IngredientHandler ingredientHandler;
    public Ingredient ingredient;
    [SerializeField]
    float radius = 10f;
    // Start is called before the first frame update
    void Start()
    {
        ingredientHandler = gameObject.GetComponent<IngredientHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Place"))
        {
        if (ingredient)
        {     
                GiveItem();
                ingredientHandler.ChangeShape(ingredient);
            }
        else
        {
            ingredient = PickUpItem();
            if (ingredient)
                ingredientHandler.ChangeShape(ingredient);
        }
        }
    }


    void GiveItem()
    {
        Collider closest = null;
        float temp;
        float tofar = radius+1f;
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach( Collider c in hitColliders)
        {
            if (c.CompareTag("Station"))
            {
                temp = Vector3.Distance(c.transform.position, gameObject.transform.position);
                if (tofar > temp)
                {
                    tofar = temp;
                    closest = c;
                }
            }
        }

        if (closest)
        {
            if(closest.gameObject.GetComponent<IHoldsIngredient>().AddIngredient(ingredient))
                ingredient = null;
        }




    }
    Ingredient PickUpItem()
    {
        Collider closest = null;
        float temp;
        float tofar = radius + 1f;
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (Collider c in hitColliders)
        {
            if (c.CompareTag("Station"))
            {
                temp = Vector3.Distance(c.transform.position, gameObject.transform.position);
                if (tofar > temp)
                {
                    tofar = temp;
                    closest = c;
                }
            }
        }

        if (closest)
        {
            return closest.gameObject.GetComponent<IHoldsIngredient>().RemoveIngredient();
        }


        

        return null;
    }
}
