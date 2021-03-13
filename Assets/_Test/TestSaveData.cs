using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test Save", menuName = "Test Save", order = 55)]
public class TestSaveData : ScriptableObject
{
    public Status status;
    public float timeSpend, staminaUsed;
    public int targetCount;
}
