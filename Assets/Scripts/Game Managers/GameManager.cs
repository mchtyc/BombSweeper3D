using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GM_Events GM_Events;
    public GM_SceneManager gM_SceneManager;
    public Transform playground;
    public GameData gameData;
    
    public int StarCount { get; private set; }

    DataFlow dataFlow;

    // Start is called before the first frame update
    void Awake()
    {
        InitGame();

        GM_Events.CallEventContinueGame();
    }

    void Start()
    {
        TestSaveManager.instance.testSave.targetCount = gameData.targetCount;

        if (GameObject.FindGameObjectWithTag("Data"))
        {
            dataFlow = GameObject.FindGameObjectWithTag("Data").GetComponent<DataFlow>();
        }

        // Development purpose: Opening menu scene even if game started from game scene
        // Does NOT effect release build
        if (dataFlow == null)
        {
            TestOpenMenuScene();
        }
    }

    void OnEnable()
    {
        GM_Events.EventStarCountChange += DecreaseStarCount;
        GM_Events.EventWin += OnWin;
    }

    void OnDisable()
    {
        GM_Events.EventStarCountChange -= DecreaseStarCount;
        GM_Events.EventWin -= OnWin;
    }

    void InitGame()
    {
        Time.timeScale = 1;
        StarCount = 3;

        // Instantiating the shape
        Instantiate(gameData.gamePrefab, playground);
    }

    public void DecreaseStarCount()
    {
        StarCount--;
    }

    public void OnWin()
    {
        dataFlow.OnWin(StarCount);
    }

    void TestOpenMenuScene()
    {
        gM_SceneManager.OpenMenu();
    }
}
