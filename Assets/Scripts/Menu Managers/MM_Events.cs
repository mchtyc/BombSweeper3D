using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_Events : MonoBehaviour
{
    public delegate void MMEventHandler();
    public delegate void MMCubicHandler(Cubic c);
    public delegate void MMSelectedCubiHandler(int id);


    public event MMCubicHandler EventSelectCubic;

    public event MMSelectedCubiHandler EventSelectedWorld;

    public MMEventHandler EventOpenGame;


    public void CallEventSelectCubic(Cubic c)
    {
        if (EventSelectCubic != null)
        {
            EventSelectCubic(c);
        }
    }

    public void CallEventSelectedWorld(int id)
    {
        if (EventSelectedWorld != null)
        {
            EventSelectedWorld(id);
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
