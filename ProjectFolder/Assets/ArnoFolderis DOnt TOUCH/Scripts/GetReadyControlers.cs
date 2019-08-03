using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetReadyControlers : MonoBehaviour
{
    [SerializeField]
    private bool[] activePlayers = { false };
    private bool coundownStated = false;
    private bool beDormant = false;
    [SerializeField]
    Game gameManager;
    GetReadyControlers getReadyControlers;
    [SerializeField]
    string sceneName = "movementScene";

    // Start is called before the first frame update
    void Start()
    {
        getReadyControlers = gameManager.GetComponent<GetReadyControlers>();
        DontDestroyOnLoad(this.gameObject);
        activePlayers = new bool[4];
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Update is called once per frame
    void Update()
    {
        if(!beDormant)
        for (int i = 0; i < 4; i++)
            if (Input.GetButtonDown("Place" + i.ToString()))
            {
                activePlayers[i] = true;
                if(!coundownStated)
                    StartCoroutine("CountDown");
                    
            }
        
    }


    IEnumerator CountDown()
    {
        coundownStated = true;
        yield return new WaitForSeconds(5f);
        beDormant = true;
        // change scene
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        
    }

    void OnSceneLoaded(Scene _scene , LoadSceneMode mode)
    {
        
        if (_scene.name == sceneName)
        {
            gameManager.StartGame(activePlayers);
            Destroy(getReadyControlers);
        }
    }

}
