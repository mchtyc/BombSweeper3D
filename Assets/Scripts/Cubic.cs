using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic : MonoBehaviour
{
    public int ID { get; private set; }
    public Animator _animator;

    public void InitData(int id)
    {
        ID = id;
        StopAnimation();
    }

    void Update()
    {
        AdjustScale();
    }

    void AdjustScale()
    {
        if (transform.position.x > -1f && transform.position.x < 1f)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (transform.position.x > -10f && transform.position.x < 10f)
        {
            float scale = 1f / (Mathf.Abs(transform.position.x) * 1.8f);
            transform.localScale = Vector3.one + new Vector3(scale, scale, scale);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }

    public void StartAnimation()
    {
        _animator.enabled = true;
        _animator.SetTrigger("start");
    }

    public void StopAnimation()
    {
        _animator.enabled = false;
    }
}
