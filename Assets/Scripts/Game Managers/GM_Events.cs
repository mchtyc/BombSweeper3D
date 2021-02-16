using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Events : MonoBehaviour
{
    public delegate void EventHandler();
    public delegate void EventDamageHandler(int damage);
    public delegate void EventBoosterHandler(GameObject booster);


    public event EventHandler EventTileFirstHit;
    public event EventHandler EventTileSecondHit;

    public event EventHandler EventCountDownFinished;

    public event EventHandler EventDecreaseTargetCount;

    public event EventHandler EventGameOver;

    public event EventHandler EventWin;

    public event EventHandler EventStartTimer;
    public event EventHandler EventPauseGame;
    public event EventHandler EventContinueGame;

    public event EventBoosterHandler EventBoosterUtility;

    public event EventHandler EventStarCountChange;

    public event EventDamageHandler EventTakeDamage;

    public void CallEventTileFirstHit()
    {
        if (EventTileFirstHit != null)
        {
            EventTileFirstHit();
        }
    }

    public void CallEventTileSecondHit()
    {
        if (EventTileSecondHit != null)
        {
            EventTileSecondHit();
        }
    }

    public void CallEventCountDownFinished()
    {
        if (EventCountDownFinished != null)
        {
            EventCountDownFinished();
        }
    }

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

    public void CallEventTakeDamage(int damage)
    {
        if (EventTakeDamage != null)
        {
            EventTakeDamage(damage);
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
}
