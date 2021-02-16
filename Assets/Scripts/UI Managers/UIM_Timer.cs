using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM_Timer : MonoBehaviour
{
    public GM_Events GM_Events;
    public Image fillImage, star1, star2, star3;
    public Color dangerColor, droppedStarColor;

    public GameData gameData;

    Coroutine runTimer;
    float startedTime, remainingTime, idleTime, stoppingTime, totalTime;
    int starCount;


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
        bool colorChanged = false, thirdStarDropped = false, secondStarDropped = false;

        while(true)
        {
            remainingTime = Time.time - startedTime - idleTime;
            float fAmount = (totalTime - remainingTime) / totalTime;
            fillImage.fillAmount = fAmount;

            if (fAmount <= 0.7f && !thirdStarDropped)
            {
                star3.color = droppedStarColor;
                GM_Events.CallEventStarCountChange();
                thirdStarDropped = true;
            }
            else if (fAmount <= 0.5f && !secondStarDropped)
            {
                star2.color = droppedStarColor;
                GM_Events.CallEventStarCountChange();
                secondStarDropped = true;
            }

            if (!colorChanged)
            {
                if (fAmount <= 0.3f)
                {
                    fillImage.color = dangerColor;
                    colorChanged = true;
                } 
            }
            
            if(fAmount <= 0f)
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
