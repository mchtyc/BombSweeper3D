using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CubicData
{
    public int[] starCounts;
    public int lastOpenedLevel;
    public int ID;

    public CubicData(int id, int levelCount) 
    {
        starCounts = new int[levelCount];
        ID = id;
        lastOpenedLevel = 1;
    }
}
