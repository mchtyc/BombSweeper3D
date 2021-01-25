using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_ToogleGame : MonoBehaviour
{
    public GM_Events GM_Events;

    // Eğer ihtiyaç olursa pause sayısı tutulup o sayı sıfır olunca continue yapılabilir

    private void OnEnable()
    {
        GM_Events.EventPauseGame += PauseGame;
        GM_Events.EventContinueGame += ContinueGame;
    }

    private void OnDisable()
    {
        GM_Events.EventPauseGame -= PauseGame;
        GM_Events.EventContinueGame -= ContinueGame;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
    }
}
