using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GM_Events GM_Events;
    public Transform playground;
    public GameData gameData;

    DataManager dataManager;

    public int StarCount { get; private set; }


    // Start is called before the first frame update
    void Awake()
    {
        InitGame();

        GM_Events.CallEventContinueGame();

    }

    private void Start()
    {
        TestSaveManager.instance.testSave.targetCount = gameData.targetCount;
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
        dataManager = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>();

        // Instantiating the shape
        Instantiate(gameData.gamePrefab, playground);
    }

    public void DecreaseStarCount()
    {
        StarCount--;
    }

    // TODO: Yeni bölümlerin ve dünyanın açılışının kontrolünü DataFlow'da yapmak lazım
    public void OnWin()
    {
        if (DataFlow.instance.cubicDatas[gameData.selectedWorld - 1].GetStarCounts(gameData.selectedLevel) < StarCount)
        {
            DataFlow.instance.cubicDatas[gameData.selectedWorld - 1].SetStarCounts(gameData.selectedLevel, StarCount);
        }

        if (DataFlow.instance.cubicDatas[gameData.selectedWorld - 1].LastOpenedLevel == gameData.selectedLevel)
        {
            if (DataFlow.instance.cubicDatas[gameData.selectedWorld - 1].LastOpenedLevel == DataFlow.instance.cubicDatas[gameData.selectedWorld - 1].LevelCount)
            {
                gameData.SetLastOpenedWorld(gameData.GetLastOpenedWorld() + 1);
                DataFlow.instance.OpenNewWorld();
            }
            else
            {
                DataFlow.instance.cubicDatas[gameData.selectedWorld - 1].LastOpenedLevel++;
            }
        }
    }
}
