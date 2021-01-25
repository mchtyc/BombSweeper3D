using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic : MonoBehaviour
{
    int ID;
    int levelCount;
    bool open;

    public void InitData(int id, int count, bool isOpened)
    {
        ID = id;
        levelCount = count;
        open = isOpened;
    }

    public int GetID()
    {
        return ID;
    }

    public int GetLevelCount()
    {
        return levelCount;
    }

    public bool GetOpen()
    {
        return open;
    }
}
