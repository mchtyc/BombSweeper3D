using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GM_Events GM_Events;
    public Transform playground;

    public GameData gameData;

    public int StarCount { get; private set; }


    // Start is called before the first frame update
    void Awake()
    {
        InitGame();

        GM_Events.CallEventContinueGame();  
    }

    void OnEnable()
    {
        GM_Events.EventStarCountChange += DecreaseStarCount;
    }

    void OnDisable()
    {
        GM_Events.EventStarCountChange -= DecreaseStarCount;
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
}
