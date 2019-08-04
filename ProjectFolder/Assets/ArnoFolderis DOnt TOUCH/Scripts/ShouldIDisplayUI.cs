using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldIDisplayUI : MonoBehaviour
{
    // get palyer reference
    GameObject[] players;
   

    [SerializeField]
    float displayDistance = 5f;

    IHoldsIngredient holder;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        holder = GetComponent<IHoldsIngredient>();
    }

    void Update()
    {
        
    }

    public bool ShouldIdisplay(Vector3 _position)
    {
        bool iShould = false;
        foreach(GameObject player in players)
        {
            if (Vector3.Distance(player.transform.position, _position) > displayDistance)
                iShould = true;
        }

        return iShould;
    }

}
