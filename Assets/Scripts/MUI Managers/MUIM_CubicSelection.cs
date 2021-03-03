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

    public void OpenCubic(int id)
    {
        CubicData cubicData = DataFlow.instance.cubicDatas[id - 1];

        if (gameData.lastOpenedWorld <= id)
        {
            MM_Enums.SetMenuPage(MenuPage.LevelPage);
            gameData.selectedWorld = id;

            StartCoroutine(InstantiateLevelBtns(cubicData));
        }
    }

    IEnumerator InstantiateLevelBtns(CubicData cubicData)
    {
        float cellSize = ((Screen.width * 92f / 100f) - (spacing * 6f)) / 5f;
        GLayout.cellSize = new Vector2(cellSize, cellSize);
        
        for (int i = 0; i < cubicData.starCounts.Length; i++)
        {
            Button btn = Instantiate(levelBtn, Contents).GetComponent<Button>();
            int level = i + 1;
            btn.GetComponentInChildren<Text>().text = "Level " + (level);

            if (cubicData.lastOpenedLevel <= i)
            {
                btn.interactable = false;
            }
            else
            {
                for (int j = 1; j <= 3; j++)
                {
                    btn.transform.GetChild(j).gameObject.SetActive(true);

                    if (cubicData.starCounts[i] >= j)
                    {
                        btn.transform.GetChild(j).gameObject.GetComponent<Image>().color = Color.white;
                    }
                }
            }

            btn.onClick.AddListener(delegate { OnClickLevelBtn(level); });

            if (i % 10 == 9)
            {
                yield return null;
            }

            // Grid level scrollunun en son geçilen levelin butonu en üste olacak şekilede kaydır
            // Butonlar açık olan levele kadar açık sonraki leveller için kapalı olacak
        }

        BG.SetActive(true);
    }

    void OnClickLevelBtn(int level)
    {
        gameData.selectedLevel = level;
        MM_Enums.SetMenuPage(MenuPage.WorldPage);   // Cubic leri silince burası levelPage de kalmalı ve 
        MM_Events.CallEventOpenGame();              // oyun oynanıp geri gelince burası direk açılmalı
    }
}
