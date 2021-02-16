using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic : MonoBehaviour
{
    [HideInInspector] public int ID { get; private set; }
    [HideInInspector] public int LevelCount { get; private set; }
    [HideInInspector] public bool Open { get; private set; }

    DataFlow dataFlow;
    [HideInInspector] public CubicData cubicData;
    
    void Start()
    {
        dataFlow = GameObject.FindGameObjectWithTag("Data").GetComponent<DataFlow>();
        cubicData = new CubicData(LevelCount, ID);
        dataFlow.AddData(cubicData);
    }

    public void InitData(int id, int count, bool isOpened)
    {
        ID = id;
        LevelCount = count;
        Open = isOpened;
    }

}
