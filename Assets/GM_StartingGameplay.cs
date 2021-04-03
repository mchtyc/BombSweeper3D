using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_StartingGameplay : MonoBehaviour
{
    public GM_Events gm_Events;
    public GameObject infoPanel;

    bool topPanelAnimationDone, bottomPanelAnimationDone,  shapeAnimationDone;
    
    public void TopPanelAnimationDone()
    {
        topPanelAnimationDone = true;

        CheckAnimations();
    }

    public void BottomPanelAnimationDone()
    {
        bottomPanelAnimationDone = true;

        CheckAnimations();
    }

    public void ShapeAnimationDone()
    {
        shapeAnimationDone = true;

        CheckAnimations();
    }

    void CheckAnimations()
    {
        if (topPanelAnimationDone && bottomPanelAnimationDone && shapeAnimationDone)
        {
            AllStartingAnimationsDone();
        }
    }

    void AllStartingAnimationsDone()
    {
        gm_Events.CallEventReadyToPlay();
        infoPanel.SetActive(true);

        Destroy(this);
    }
}
