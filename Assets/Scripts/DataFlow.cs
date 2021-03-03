using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataFlow : MonoBehaviour
{
    public GameData gameData;
    public DataManager dataManager;
    public MenuManager menuManager;

    [HideInInspector] public List<CubicData> cubicDatas;

    public static DataFlow instance;
    
    void Awake()
    {
        DontDestroyOnLoad(this);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GetCubicDatasFromLocal();
    }

    void GetCubicDatasFromLocal()
    {
        cubicDatas = new List<CubicData>();

        for (int i = 1; i <= gameData.lastOpenedWorld; i++)
        {
            CubicData cubicData = new CubicData(i, menuManager.gameDatabase.Worlds[i].Levels.Length);
            cubicDatas.Add(cubicData);
            dataManager.LoadFromLocal(cubicData.ID);
        }
    }
}
