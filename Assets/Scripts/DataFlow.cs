using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataFlow : MonoBehaviour
{
    public GameData gameData;
    public DataManager dataManager;

    [HideInInspector] public CubicData[] cubicDatas;

    static GameObject instance;
    
    void Awake()
    {
        DontDestroyOnLoad(this);

        if(instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        cubicDatas = new CubicData[gameData.worldCount];
    }

    public void AddData(CubicData data)
    {
        cubicDatas[data.ID - 1] = data;
        SavingCubicData(data);
    }

    void SavingCubicData(CubicData data)
    {
        data = dataManager.LoadFromLocal(data);

        if (data == null)
        {
            dataManager.SaveToLocal(data);
        }

        // Bu kısım level oynanır oynanmaz gamescene de işlenebilir
        //if (gameData.isPlayed)
        //{
        //    if (data.ID == gameData.selectedWorld)
        //    {
        //        data.starCounts[gameData.selectedLevel - 1] = gameData.starCount;

        //        if (data.lastOpenedLevel == gameData.selectedLevel)
        //        {
        //            data.lastOpenedLevel++;
        //        }


        //        if (gameData.selectedLevel == data.starCounts.Length)
        //        {
        //            gameData.lastOpenedWorld++;
        //            dataManager.SaveToLocal();
        //        }

        //        dataManager.SaveToLocal(data);
        //        gameData.isPlayed = false;
        //    }
        //}
    }
}
