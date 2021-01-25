using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MUIM_CubicSelection : MonoBehaviour
{
    public GameObject BG, levelBtn;
    public Transform Contents;
    public MM_Events MM_Events;
    public GridLayoutGroup GLayout;
    public RectTransform RTrans;
    public GameData gameData;

    float spacing = 50f;

    private void OnEnable()
    {
        MM_Events.EventSelectCubic += OpenCubic;
    }

    private void OnDisable()
    {
        MM_Events.EventSelectCubic -= OpenCubic;
    }

    public void OpenCubic(Cubic cubic)
    {
        if (cubic.GetOpen())
        {
            MM_Enums.SetMenuPage(MenuPage.LevelPage);
            gameData.playingWorldId = cubic.GetID();

            StartCoroutine(InstantiateLevelBtns(cubic.GetLevelCount()));
        }
    }    

    IEnumerator InstantiateLevelBtns(int levelCount)
    {
        float cellSize = ((Screen.width * 92f / 100f) - (spacing * 6f)) / 5f;
        GLayout.cellSize = new Vector2(cellSize, cellSize);
        
        for (int i = 0; i < levelCount; i++)
        {
            Button btn = Instantiate(levelBtn, Contents).GetComponent<Button>();
            int level = i + 1;
            btn.GetComponentInChildren<Text>().text = "Level " + (level);

            btn.onClick.AddListener(delegate { OnClickLevelBtn(level); });

            if (i % 10 == 9)
            {
                yield return null;
            }

            // Grid level scrollunun en son geçilen levelin butonu en üste olacak şekilede kadır
            // Butonlar açık olan levele kadar açık sonraki leveller için kapalı olacak
        }

        BG.SetActive(true);
    }

    void OnClickLevelBtn(int level)
    {
        gameData.playingLevel = level;
        MM_Enums.SetMenuPage(MenuPage.WorldPage);
        MM_Events.CallEventOpenGame();
    }
}
