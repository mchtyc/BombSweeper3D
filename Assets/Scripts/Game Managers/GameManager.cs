using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GM_Events GM_Events;
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
}
