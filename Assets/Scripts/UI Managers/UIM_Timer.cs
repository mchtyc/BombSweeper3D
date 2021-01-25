using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM_Timer : MonoBehaviour
{
    public GM_Events GM_Events;
    public Image fillImage;
    public Color dangerColor;

    public GameData gameData;

    Coroutine runTimer;
    float startedTime, remainingTime, idleTime, stoppingTime, totalTime;

    private void OnEnable()
    {
        GM_Events.EventStartTimer += OnStartTimer;
        GM_Events.EventPauseGame += PauseTimer;
        GM_Events.EventContinueGame += ContinueTimer;

        totalTime = gameData.duration;
    }

    private void OnDisable()
    {
        GM_Events.EventStartTimer -= OnStartTimer;
        GM_Events.EventPauseGame -= PauseTimer;
        GM_Events.EventContinueGame -= ContinueTimer;
    }

    public void OnStartTimer()
    {
        startedTime = Time.time;
        runTimer = StartCoroutine(ChangeTimer(idleTime));
    }

    IEnumerator ChangeTimer(float idle)
    {
        bool changeColor = false;

        while(true)
        {
            remainingTime = Time.time - startedTime - idleTime;
            fillImage.fillAmount = (totalTime - remainingTime) / totalTime;

            if (!changeColor)
            {
                if (fillImage.fillAmount <= 0.3f)
                {
                    fillImage.color = dangerColor;
                    changeColor = true;
                } 
            }
            
            if(fillImage.fillAmount <= 0f)
            {
                GM_Events.CallEventGameOver();
            }

            yield return null;
        }
    }

    public void PauseTimer()
    {
        stoppingTime = Time.time;
        StopCoroutine(runTimer);
    }

    public void ContinueTimer()
    {
        idleTime = Time.time - stoppingTime;
        StartCoroutine(ChangeTimer(idleTime));
    }
}
