using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CubicData
{
    int[] starCounts;
    int lastOpenedLevel;
    int levelAmount;
    public int LastOpenedLevel 
    {
        get 
        {
            return lastOpenedLevel; 
        }
        set
        {
            lastOpenedLevel = value;
            DataManager.instance.SaveToLocal(ID);
        }
    }
    public int LevelCount{ get { return levelAmount; } private set {  } }
    public int ID;
    
    public CubicData(int id, int levelCount) 
    {
        levelAmount = levelCount;
        starCounts = new int[levelCount];
        ID = id;
        lastOpenedLevel = 1;
    }

    public void SetStarCounts(int level, int count)
    {
        starCounts[level - 1] = count;
        DataManager.instance.SaveToLocal(ID);
    }

    public int GetStarCounts(int level)
    {
        return starCounts[level - 1];
    }
}
