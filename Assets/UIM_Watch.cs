using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIM_Watch : MonoBehaviour
{
    public Animator yelkovanAnimator;
    public GM_Events gm_Events;

    void OnEnable()
    {
        gm_Events.EventStartTimer += EnableYelkovanAnimation;
    }
    
    void OnDisable()
    {
        gm_Events.EventStartTimer -= EnableYelkovanAnimation;
    }

    public void EnableYelkovanAnimation()
    {
        yelkovanAnimator.enabled = true;
    }

    public void DisableYelkovanAnimation()
    {
        yelkovanAnimator.enabled = false;
    }
}
