using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Level
{
    [SerializeField] Sprite targetSprite;
    [SerializeField] int targetCount;
    [SerializeField] float duration, stamina;

    public Sprite TargetSprite { get { return targetSprite; } }
    public int TargetCount { get { return targetCount; } }
    public float Duration { get { return duration; } }
    public float Stamina { get { return stamina; } }
}
