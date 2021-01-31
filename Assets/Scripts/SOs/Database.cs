using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Database", fileName = "Game Database", order = 53)]
public class Database : ScriptableObject
{
    [SerializeField] World[] worlds;

    public World[] Worlds { get { return worlds; } }
}
