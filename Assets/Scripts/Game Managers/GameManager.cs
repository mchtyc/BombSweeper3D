using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GM_Events GM_Events;
    public Transform playground;

    public GameData gameData;


    // Start is called before the first frame update
    void Awake()
    {
        InitGame();

        GM_Events.CallEventContinueGame();  
    }

    void InitGame()
    {
        // Instantiating the shape
        Instantiate(gameData.gamePrefab, playground);
    }
}
