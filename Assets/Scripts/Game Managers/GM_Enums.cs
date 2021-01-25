using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates { Clickable, Nonclickable, Booster}
public enum GamePhases { FirstSelection, Started}

public class GM_Enums : MonoBehaviour
{
    static GameStates gameState;
    static int nonClickableCount;

    static GamePhases gamePhase;

    private void Start()
    {
        gameState = GameStates.Clickable;
        nonClickableCount = 0;

        gamePhase = GamePhases.FirstSelection;
    }

    public static void ChangeGameState(GameStates state)
    {
        if (state != gameState)
        {
            if (state == GameStates.Nonclickable)
            {
                nonClickableCount++;
                gameState = state;
            }
            else
            {
                nonClickableCount--;

                if (nonClickableCount <= 0)
                {
                    nonClickableCount = 0;
                    gameState = state;
                }
            }
        }
    }

    public static GameStates GetGameState() 
    {
        return gameState;
    }

    public static void ChangeGamePhase(GamePhases phase)
    {
        gamePhase = phase;
    }

    public static GamePhases GetGamePhase()
    {
        return gamePhase;
    }
}
