using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Game Data", menuName = "Game Data", order = 51)]
public class GameData : ScriptableObject
{
    public GameObject cubic;
    public Sprite target;
    public float duration, stamina;
    public int targetCount; 
    
    public int playingWorldId;
    public int playingLevel;

    // Bölümü oynadıktan sonra geri döndürülecek yıldız sayısı puan... gibi bilgiler

}
