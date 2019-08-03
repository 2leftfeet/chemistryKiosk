using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GetReadyControlers : MonoBehaviour
{
    [SerializeField]
    TMP_Text timer;

    [SerializeField]
    GameObject[] TimerGO;

    [SerializeField]
    GameObject[] Checkmarks;


    [SerializeField]
    private bool[] activePlayers = { false };

    private bool coundownStated = false;
    private bool beDormant = false;
    [SerializeField]
    private float waitAmount = 5f;
    private float waitAmountCounting;
    [SerializeField]
    Game gameManager;
    GetReadyControlers getReadyControlers;
    [SerializeField]
    string sceneName = "movementScene";

    // Start is called before the first frame update
    void Start()
    {
        waitAmountCounting = waitAmount;
        getReadyControlers = gameManager.GetComponent<GetReadyControlers>();
        DontDestroyOnLoad(this.gameObject);
        activePlayers = new bool[4];
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Update is called once per frame
    void Update()
    {
        if (coundownStated)
        {
            waitAmountCounting -= Time.deltaTime;
            timer.text = Mathf.Round(waitAmountCounting).ToString();
        }

        if (!beDormant)
        for (int i = 0; i < 4; i++)
            if (Input.GetButtonDown("Place" + i.ToString()))
            {
                // activate chekmarks for ui
                if (!activePlayers[i])
                    Checkmarks[i].SetActive(true);
                activePlayers[i] = true;

                if(!coundownStated)
                    StartCoroutine("CountDown");
                    
            }
        
    }


    IEnumerator CountDown()
    {
        TimerGO[0].SetActive(true);
        TimerGO[1].SetActive(true);
        coundownStated = true;
        yield return new WaitForSeconds(waitAmount);
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
