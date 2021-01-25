using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Board : MonoBehaviour
{
    public GameManager GM;
    public Transform shape;
    public GM_Events GM_Events;

    public GameData gameData;

    int possiblity = 10;
    int targetCount;

    private void Start()
    {
        targetCount = gameData.targetCount;
        shape = GameObject.FindGameObjectWithTag("Cubic").transform;
    }

    public void SetupBoard(Tile firstClick)
    {
        int unplacableCount = firstClick.MakeAroundUnplacable();

        List<Tile> allTiles = GetTiles();
        int tileRemain = allTiles.Count - unplacableCount;

        // Placing Targets
        foreach(Tile t in allTiles)
        {
            if (t.unplacable)
            {
                continue;
            }

            if (targetCount > 0)
            {
                if (tileRemain > targetCount)
                {
                    if (Random.Range(0, possiblity) == 0)
                    {
                        PutTarget(t);
                    }
                }
                else if (tileRemain == targetCount)
                {
                    PutTarget(t);
                }
                else
                {
                    Debug.LogError("Not enough tiles to handle target count!");
                }
            }
            else
            {
                break;
            }

            tileRemain--;
        }

        // Opening FirstClick
        OpenFirstClick(firstClick);
        GM_Events.CallEventStartTimer();
    }

    private void OpenFirstClick(Tile t)
    {
        t.OpenTile(1);
    }

    void PutTarget(Tile t)
    {
        targetCount--;
        t.PutTarget();
    }

    List<Tile> GetTiles()
    {
        List<Tile> allTiles = new List<Tile>();

        for (int i = 0; i < shape.childCount; i++)
        {
            for (int j = 0; j < shape.GetChild(i).childCount; j++)
            {
                allTiles.Add(shape.GetChild(i).GetChild(j).GetComponent<Tile>());
            }
        }

        return allTiles;
    }
}
