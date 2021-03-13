using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIM_Win : MonoBehaviour
{
    public GM_Events GM_Events;
    public GameManager GM;
    public GameObject WinPanel;
    public GameData gameData;

    private void OnEnable()
    {
        GM_Events.EventWin += OnWin;
        WinPanel.SetActive(false);
    }

    private void OnDisable()
    {
        GM_Events.EventWin -= OnWin;
    }

    public void OnWin()
    {
        GM_Enums.ChangeGameState(GameStates.Nonclickable);
        gameData.starCount = GM.StarCount;
        TestSaveManager.instance.testSave.status = Status.Pass;
        WinPanel.SetActive(true);
        GM_Events.CallEventPauseGame();
    }
}
    