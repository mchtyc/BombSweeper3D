using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public Animator _animator;

    public void OnAnimationDone()
    {
        GameObject.FindGameObjectWithTag("Managers").GetComponent<GM_StartingGameplay>().ShapeAnimationDone();

        Destroy(_animator);
        Destroy(this);
    }
}
