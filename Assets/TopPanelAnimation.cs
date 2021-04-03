using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPanelAnimation : MonoBehaviour
{
    public GM_StartingGameplay gm_StartingGameplay;
    public Animator _animator;

    public void OnAnimationDone()
    {
        gm_StartingGameplay.TopPanelAnimationDone();
        Destroy(_animator);
        Destroy(this);
    }
}
