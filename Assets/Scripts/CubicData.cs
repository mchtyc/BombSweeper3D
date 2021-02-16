using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubicData
{
    public int[] starCounts;
    public int lastOpenedLevel;
    public int ID;

    public CubicData(int levelCount, int id) 
    {
        starCounts = new int[levelCount];
        ID = id;
        lastOpenedLevel = 1;
    }
}
