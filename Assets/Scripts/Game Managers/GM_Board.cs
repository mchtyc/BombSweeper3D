using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Board : MonoBehaviour
{
    public GameManager GM;
    public Transform shape;
    public GM_Events GM_Events;

    public GameData gameData;

    int targetCount;

    private void Start()
    {
        targetCount = gameData.targetCount;
        shape = GameObject.FindGameObjectWithTag("Cubic").transform;
    }

    public void SetupBoard(Tile firstClick)
    {
        int unplacableCount = firstClick.MakeAroundUnplacable();

        // Placing Targets
        List<Tile> allTiles = GetTiles();
        int totalCount = allTiles.Count;

        int firstIndex = 0, lastIndex = 0;

        for (int i = 1; i <= targetCount; i++)
        {
            lastIndex = (totalCount  * i) / targetCount;

            int place = Random.Range(firstIndex, lastIndex);
            PutTarget(allTiles[place]);
            
            firstIndex = lastIndex;
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
        t.PutTarget();
    }

    List<Tile> GetTiles()
    {
        List<Tile> allTiles = new List<Tile>();

        for (int i = 0; i < shape.childCount; i++)
        {
            for (int j = 0; j < shape.GetChild(i).childCount; j++)
            {
                if (!shape.GetChild(i).GetChild(j).GetComponent<Tile>().unplacable)
                {
                    allTiles.Add(shape.GetChild(i).GetChild(j).GetComponent<Tile>());
                }
            }
        }

        return allTiles;
    }
}
