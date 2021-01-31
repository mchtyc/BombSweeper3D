using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Game Data", order = 51)]
public class GameData : ScriptableObject
{
    public GameObject gamePrefab;
    public Sprite targetSprite;
    public float duration, stamina;
    public int targetCount, selectedWorld, lastOpenedWorld, selectedLevel, boosterCount;
    public int[] lastOpenedLevels;

    // Bölümü oynadıktan sonra geri döndürülecek yıldız sayısı puan... gibi bilgiler
}
