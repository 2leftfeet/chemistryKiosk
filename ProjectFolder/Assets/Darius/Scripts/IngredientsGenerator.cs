using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsGenerator : MonoBehaviour
{
    [System.Serializable]
    class ConveyorIngredients
    {
        public Ingredient ingredient;
        public bool isPresent;
        public int count;

        
    }

    [SerializeField]
    List<Ingredient> needTaskIngredients = new List<Ingredient>();

    [SerializeField]
    List<ConveyorIngredients> neededIngredients = new List<ConveyorIngredients>();


    public void AddIngredients(TaskData task)
    {
        for(int i = 0; i < task.neededIngredients.Count; i++)
        {
            if(!task.neededIngredients[i].craftable)
            {
                needTaskIngredients.Add(task.neededIngredients[i]);
                UpdateList();
            }
                
        }
    }


    public void RemoveIngredients(TaskData task)
    {
        for(int i = 0; i < task.neededIngredients.Count; i++)
        {
            for(int a = 0; a < neededIngredients.Count; a++)
            {
                if(neededIngredients[a].ingredient == task.neededIngredients[i])
                {
                    if(neededIngredients[a].count > 1)
                    {
                        neededIngredients[a].count--;
                    }
                    else if(neededIngredients[a].count == 1)
                    {
                        neededIngredients.Remove(neededIngredients[a]);
                    }

                }
            }
        }
    }

    private void UpdateList()
    {
        if (needTaskIngredients.Count > 0)
        {
            for (int i = 0; i < needTaskIngredients.Count; i++)
            {
                bool addToConveyor = true;
                if (neededIngredients.Count > 0)
                {
                    for (int a = 0; a < neededIngredients.Count; a++)
                    {
                        if (neededIngredients[a].ingredient == needTaskIngredients[i])
                        {
                            addToConveyor = false;
                            neededIngredients[a].count++;
                            needTaskIngredients.Remove(needTaskIngredients[i]);
                            break;
                        }

                    }
                }


                if (addToConveyor && needTaskIngredients.Count > 0)
                {
                    ConveyorIngredients addedIngredient = new ConveyorIngredients();
                    addedIngredient.ingredient = needTaskIngredients[i];
                    addedIngredient.isPresent = true;
                    addedIngredient.count = 1;
                    needTaskIngredients.Remove(needTaskIngredients[i]);
                    neededIngredients.Add(addedIngredient);
                }
            }
        }
    }


    private void Update()
    {
        

        

    }


}
