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
        public Counter dedicatedCounter;
        
    }

    [SerializeField]
    List<Ingredient> needTaskIngredients = new List<Ingredient>();

    [SerializeField]
    List<ConveyorIngredients> neededIngredients = new List<ConveyorIngredients>();

    [SerializeField]
    List<Counter> conveyorCounters = new List<Counter>();


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
                        neededIngredients[a].dedicatedCounter.RemoveIngredient();
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
                    for (int b = 0; b < conveyorCounters.Count; b++)
                    {
                        if(conveyorCounters[b].ingredient == null &&  !conveyorCounters[b].IsInScene() )
                        {
                            addedIngredient.dedicatedCounter = conveyorCounters[b];
                            conveyorCounters[b].GenerateIngredient(addedIngredient.ingredient);
                            break;
                        }
                    }
                    needTaskIngredients.Remove(needTaskIngredients[i]);
                    neededIngredients.Add(addedIngredient);
                }
            }
        }
    }

  /*  private void UpdateCountersAdd(Ingredient ing)
    {
        for(int i = 0; i < conveyorCounters.Count; i++)
        {
            if(conveyorCounters[i].ingredient == null)
            {
                conveyorCounters[i].AddIngredient(ing);
            }
        }
    }*/

    void CheckForCoveyorUpdates()
    {
        for(int i = 0; i < neededIngredients.Count; i++)
        {

            if(neededIngredients[i].dedicatedCounter != null)
            {
                if (!neededIngredients[i].dedicatedCounter.IsInScene() && neededIngredients[i].dedicatedCounter.ingredient == null)
                {
                    neededIngredients[i].dedicatedCounter.GenerateIngredient(neededIngredients[i].ingredient);
                }
            }


            
        }
    }



    private void Update()
    {

        CheckForCoveyorUpdates();
        

    }


}
