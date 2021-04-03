using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIM_InfoPanel : MonoBehaviour
{
    public GM_Events gm_Events;
    public GameObject infoPanel;

    void OnEnable()
    {
        gm_Events.EventStartTimer += DisablePanel;
    }

    void OnDisable()
    {
        gm_Events.EventStartTimer -= DisablePanel;
    }

    public void DisablePanel()
    {
        Destroy(infoPanel);
    }
}
