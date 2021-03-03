using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_Events : MonoBehaviour
{
    public delegate void MMEventHandler();
    public delegate void MMCubicHandler(int id);


    public MMEventHandler EventOpenGame;

    public event MMCubicHandler EventSelectCubic;
    public event MMCubicHandler EventWorldOnFocus;

    public void CallEventSelectCubic(int id)
    {
        if (EventSelectCubic != null)
        {
            EventSelectCubic(id);
        }
    }

    public void CallEventWorldOnFocus(int id)
    {
        if (EventWorldOnFocus != null)
        {
            EventWorldOnFocus(id);
        }
    }

    public void CallEventOpenGame()
    {
        if(EventOpenGame != null)
        {
            EventOpenGame();
        }
    }
}
