using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUIM_BtnClicks : MonoBehaviour
{
    public GameObject LevelsBG;
    public Transform Contents;

    public void OnClickLevelsBack()
    {
        StartCoroutine(MenuClosingDelay());
    }

    IEnumerator MenuClosingDelay()
    {
        yield return new WaitForSeconds(0.5f);
        MM_Enums.SetMenuPage(MenuPage.WorldPage);
        LevelsBG.SetActive(false);
        DestroyOldButtons();
    }

    void DestroyOldButtons()
    {
        int count = Contents.childCount;

        // İlerde object pooling ayarla
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                Destroy(Contents.GetChild(i).gameObject);
            }
        }
    }
}