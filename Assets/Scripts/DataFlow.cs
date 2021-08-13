using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataFlow : MonoBehaviour
{
    public GameData gameData;
    public DataManager dataManager;
    
    [HideInInspector] public List<CubicData> cubicDatas;
    
    public static DataFlow instance;

    MenuManager menuManager;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        menuManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<MenuManager>();
        GetCubicDatasFromLocal();
    }

    void GetCubicDatasFromLocal()
    {
        cubicDatas = new List<CubicData>();

        for (int i = 1; i <= gameData.GetLastOpenedWorld(); i++)
        {
            CubicData cubicData = new CubicData(i, menuManager.gameDatabase.Worlds[i - 1].Levels.Length);
            cubicDatas.Add(cubicData);
            dataManager.LoadFromLocal(cubicData.ID);
        }
    }

    public void OpenNewWorld()
    {
        CubicData cubicData = new CubicData(gameData.GetLastOpenedWorld(), menuManager.gameDatabase.Worlds[gameData.GetLastOpenedWorld() - 1].Levels.Length);
        cubicDatas.Add(cubicData);
        dataManager.LoadFromLocal(cubicData.ID);
    }

    public void OnWin(int starCount)
    {
        CubicData world = cubicDatas[gameData.selectedWorld - 1];

        if ( world.GetStarCounts(gameData.selectedLevel) < starCount)
        {
            world.SetStarCounts(gameData.selectedLevel, starCount);
        }

        // Açılan level arttırma ve yeni dünya açma
        if (world.LastOpenedLevel == gameData.selectedLevel && gameData.GetLastOpenedWorld() == gameData.selectedWorld)
        {
            if (world.LastOpenedLevel == world.LevelCount)
            {
                gameData.SetLastOpenedWorld(gameData.GetLastOpenedWorld() + 1);
                OpenNewWorld();
            }
            else
            {
                world.LastOpenedLevel++;
            }
        }
    }
}
