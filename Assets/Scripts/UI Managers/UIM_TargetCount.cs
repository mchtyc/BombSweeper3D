using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM_TargetCount : MonoBehaviour
{
    public GM_Events GM_Events;
    public Image targetImage;
    public GameData gameData;

    public Text targetCountdown;

    int amount;

    private void OnEnable()
    {
        GM_Events.EventDecreaseTargetCount += ChangeTargetCount;

        amount = gameData.targetCount;
        WriteTargetCount();
        targetImage.sprite = gameData.targetSprite;
    }

    private void OnDisable()
    {
        GM_Events.EventDecreaseTargetCount -= ChangeTargetCount;
    }

    public void ChangeTargetCount()
    {
        amount--;
        WriteTargetCount();
        CheckWinnigCondition();
    }

    void WriteTargetCount() 
    {
        targetCountdown.text = amount.ToString();
    }

    void CheckWinnigCondition()
    {
        if (amount <= 0)
        {
            // Game Won
            GM_Events.CallEventWin();
        }
    }
}
