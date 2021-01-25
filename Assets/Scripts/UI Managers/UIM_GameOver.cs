using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIM_GameOver : MonoBehaviour
{
    public GameObject GOPanel;
    public GM_Events GM_Events;

    private void OnEnable()
    {
        GM_Events.EventGameOver += OnGameOver;
        GOPanel.SetActive(false);
    }

    private void OnDisable()
    {
        GM_Events.EventGameOver -= OnGameOver;
    }

    public void OnGameOver()
    {
        GM_Enums.ChangeGameState(GameStates.Nonclickable);
        GOPanel.SetActive(true);
        GM_Events.CallEventPauseGame();
    }
}
