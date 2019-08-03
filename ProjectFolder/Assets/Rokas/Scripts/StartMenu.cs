using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TMP_Text playerText;
    private int playerCount = 1;
    public void ChangePayerForward()
    {
        if (playerCount < 4)
        {
            playerCount++;
            Debug.Log(playerCount);
        }
        else
        {
            playerCount = 1;
            Debug.Log(playerCount);
        }
        UpdateText();
    }

    public void ChangePayerBackwards()
    {
        if (playerCount > 1)
        {
            playerCount--;
            Debug.Log(playerCount);
        }
        else
        {
            playerCount = 4;
            Debug.Log(playerCount);
        }
        UpdateText();
    }

    void UpdateText()
    {
        playerText.text = playerCount + " PLAYER";
        if (playerCount > 1)
        {
            playerText.text += "S";
        }
    }

    public void StartScene()
    {
        Debug.Log("SCENE CHANGE!");
    }
}
