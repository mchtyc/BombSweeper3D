using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPanelAnimation : MonoBehaviour
{
    public GM_StartingGameplay gm_StartingGameplay;
    public Animator _animator;

    public void OnAnimationDone()
    {
        gm_StartingGameplay.BottomPanelAnimationDone();
        Destroy(_animator);
        Destroy(this);
    }
}
