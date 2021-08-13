using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIM_TargetFoundAnimation : MonoBehaviour
{
    public GM_Events gM_Events;
    public GameObject targetPre;
    public Transform canvas;

    void OnEnable()
    {
        gM_Events.EventTargetFound += OnTargetFound;
    }

    void OnDisable()
    {
        gM_Events.EventTargetFound -= OnTargetFound;
    }

    void OnTargetFound(Vector3 initialPos)
    {
        initialPos = Camera.main.WorldToScreenPoint(initialPos);
        Instantiate(targetPre, initialPos, Quaternion.identity, canvas);
    }
}
