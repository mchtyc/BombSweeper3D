using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM_LevelComplete : MonoBehaviour
{
    public GameObject levelComplete, winTitle, lostTitle, star1, star2, star3, winBtns, lostBtns;
    public Text levelText;

    public GM_Events gM_Events;
    public GameManager gManager;
    public GameData gameData;

    void OnEnable()
    {
        gM_Events.EventWin += OpenWinPanels;
        gM_Events.EventGameOver += OpenLostPanels;
        levelComplete.SetActive(false);
    }

    void OnDisable()
    {
        gM_Events.EventWin -= OpenWinPanels;
        gM_Events.EventGameOver -= OpenLostPanels;
    }

    void OpenLevelFinishedPanel()
    {
        levelComplete.SetActive(true);
        levelText.text = "LEVEL " + gameData.selectedLevel;
    }

    void OpenWinPanels()
    {
        GM_Enums.ChangeGameState(GameStates.Nonclickable);
        gameData.starCount = gManager.StarCount;

        CloseLostPanels();
        CloseStars();
        OpenLevelFinishedPanel();

        winTitle.SetActive(true);
        winBtns.SetActive(true);

        if (gameData.starCount == 1)
        {
            star1.SetActive(true);
        }
        else if (gameData.starCount == 2)
        {
            star2.SetActive(true);
        }
        else if (gameData.starCount == 3)
        {
            star3.SetActive(true);
        }

        StartCoroutine(WaitToPause());
    }

    void OpenLostPanels()
    {
        GM_Enums.ChangeGameState(GameStates.Nonclickable);
        CloseWinPanels();
        OpenLevelFinishedPanel();

        lostTitle.SetActive(true);
        lostBtns.SetActive(true);

        StartCoroutine(WaitToPause());
    }

    void CloseWinPanels()
    {
        winTitle.SetActive(false);
        winBtns.SetActive(false);

        CloseStars();
    }

    void CloseLostPanels()
    {
        lostTitle.SetActive(false);
        lostBtns.SetActive(false);
    }

    void CloseStars()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    IEnumerator WaitToPause()
    {
        yield return new WaitForSeconds(1f);

        gM_Events.CallEventPauseGame();
    }
}
