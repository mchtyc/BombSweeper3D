using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class World
{
    [SerializeField] int id;
    [SerializeField] string worldName;
    [SerializeField] GameObject menuPrefabOpened, menuPrefabClosed, gamePrefab;
    [SerializeField] Level[] levels;

    public int ID { get { return id; } }
    public string WorldName { get { return worldName; } }
    public GameObject MenuPrefabOpened { get { return menuPrefabOpened; } }
    public GameObject MenuPrefabClosed { get { return menuPrefabClosed; } }
    public GameObject GamePrefab { get { return gamePrefab; } }
    public Level[] Levels { get { return levels; } }
}
