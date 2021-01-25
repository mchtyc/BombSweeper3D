using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM_CountDown : MonoBehaviour
{
    public GM_Events GM_Events;
    public Text countDownText;
    public Image countDownPanel;

    public float boomTime;
    public Color safeColor, dangerColor, boomColor;

    Coroutine countdownCoroutine;
   
    // TO DO: Renk geçişlerini yumuşat
    
    private void OnEnable()
    {
        GM_Events.EventTileFirstHit += StartCountDown;
        GM_Events.EventTileSecondHit += FinishCountDown;
    }

    private void OnDisable()
    {
        GM_Events.EventTileFirstHit -= StartCountDown;
        GM_Events.EventTileSecondHit -= FinishCountDown;
    }

    public void StartCountDown()
    {
        countDownPanel.color = dangerColor;
        countdownCoroutine = StartCoroutine(IStartCountDown(boomTime));
    }

    public void FinishCountDown()
    {
        StopCoroutine(countdownCoroutine);
        countDownText.text = "";
        countDownPanel.color = safeColor;
    }

    IEnumerator IStartCountDown(float counter)
    {
        while (counter >= 0f)
        {
            if(counter < boomTime / 4f)
            {
                countDownPanel.color = boomColor;
            }

            countDownText.text = ((int)counter).ToString();
            yield return null;
            counter -= Time.deltaTime * 15f;
        }

        GM_Events.CallEventCountDownFinished();
        FinishCountDown();
    }
}
