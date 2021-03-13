using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Game Data", order = 51)]
public class GameData : ScriptableObject
{
    public GameObject gamePrefab;
    public Sprite targetSprite;
    public float duration, stamina;
    public int targetCount, selectedWorld, selectedLevel;

    [SerializeField]
    int lastOpenedWorld;

    [SerializeField]
    int boosterCount;

    // Bölümü oynadıktan sonra geri döndürülecek yıldız sayısı puan... gibi bilgiler
    public int starCount;

    public void SetLastOpenedWorld(int count)
    {
        lastOpenedWorld = count;
        SavingData();
    }

    public int GetLastOpenedWorld()
    {
        return lastOpenedWorld;
    }

    public void SetBoosterCount(int count)
    {
        boosterCount = count;
        SavingData();
    }

    public int GetBoosterCount()
    {
        return boosterCount;
    }

    void SavingData()
    {
        DataManager.instance.SaveToLocal();
    }
}