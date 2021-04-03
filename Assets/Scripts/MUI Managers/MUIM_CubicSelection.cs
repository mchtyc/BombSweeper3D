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

    float spacing;

    private void OnEnable()
    {
        spacing = Screen.width / 40f;
        MM_Events.EventSelectCubic += OpenCubic;
    }

    private void OnDisable()
    {
        MM_Events.EventSelectCubic -= OpenCubic;
    }

    public void OpenCubic(int id)
    {
        CubicData cubicData = DataFlow.instance.cubicDatas[id - 1];

        if (gameData.GetLastOpenedWorld() >= id)
        {
            MM_Enums.SetMenuPage(MenuPage.LevelPage);
            gameData.selectedWorld = id;

            StartCoroutine(InstantiateLevelBtns(cubicData));
        }
    }

    IEnumerator InstantiateLevelBtns(CubicData cubicData)
    {
        yield return null;

        BG.SetActive(true);

        float cellSize = ((Screen.width * 82f / 100f) - (spacing * 6f)) / 5f;
        GLayout.cellSize = new Vector2(cellSize, cellSize);
        GLayout.spacing = new Vector3(spacing, 3 * spacing / 2);

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < cubicData.LevelCount; i++)
        {
            LevelBtn btn = Instantiate(levelBtn, Contents).GetComponent<LevelBtn>();
            int level = i + 1;
            
            if (cubicData.LastOpenedLevel <= i)
            {
                btn.Deactivate();
            }
            else
            {
                btn.InitialDatas(level, cubicData.GetStarCounts(i + 1), MM_Events);
            }
                
            yield return null;


            // Grid level scrollunun en son geçilen levelin butonu en üste olacak şekilede kaydır
            // Butonlar açık olan levele kadar açık sonraki leveller için kapalı olacak
        }
    }
}
