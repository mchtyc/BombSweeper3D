using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Events : MonoBehaviour
{
    public delegate void EventHandler();
    public delegate void EventDamageHandler(int damage, Vector3 pos);
    public delegate void EventBoosterHandler(GameObject booster);



    public event EventHandler EventDecreaseTargetCount;

    public event EventHandler EventGameOver;

    public event EventHandler EventWin;

    public event EventHandler EventStartTimer;
    public event EventHandler EventPauseGame;
    public event EventHandler EventContinueGame;

    public event EventBoosterHandler EventBoosterUtility;

    public event EventHandler EventStarCountChange;

    public event EventDamageHandler EventTakeDamage;

    public event EventHandler EventReadyToPlay;


    public void CallEventDecreaseTargetCount()
    {
        if (EventDecreaseTargetCount != null)
        {
            EventDecreaseTargetCount();
        }
    }

    public void CallEventGameOver()
    {
        if (EventGameOver != null)
        {
            EventGameOver();
        }
    }

    public void CallEventTakeDamage(int damage, Vector3 pos)
    {
        if (EventTakeDamage != null)
        {
            EventTakeDamage(damage, pos);
        }
    }

    public void CallEventWin()
    {
        if (EventWin != null)
        {
            EventWin();
        }
    }

    public void CallEventStartTimer()
    {
        if (EventStartTimer != null)
        {
            EventStartTimer();
        }
    }

    public void CallEventPauseGame()
    {
        if (EventPauseGame != null)
        {
            EventPauseGame();
        }
    }

    public void CallEventContinueGame()
    {
        if (EventContinueGame != null)
        {
            EventContinueGame();
        }
    }

    public void CallEventBoosterUtility(GameObject booster)
    {
        if (EventBoosterUtility != null)
        {
            EventBoosterUtility(booster);
        }
    }

    public void CallEventStarCountChange()
    {
        if (EventStarCountChange != null)
        {
            EventStarCountChange();
        }
    }

    public void CallEventReadyToPlay()
    {
        if(EventReadyToPlay != null)
        {
            EventReadyToPlay();
        }
    }
}
