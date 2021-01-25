using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class World
{
    public GameObject WorldPrefab, closedPrefab, gamePrefab;
    public Level[] levels;
    public string Name;
    
    public int id, levelCount;
    public bool open;
}
