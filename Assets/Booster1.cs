using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster1 : Booster
{
    protected override void InitialState()
    {
        range = boosterData.booster1Range;
        base.InitialState();
    }

    protected override IEnumerator Detonate()
    {
        yield return new WaitForSeconds(0.2f);

        GetComponentInChildren<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(0.3f);

        List<Tile> tiles = selectedTile.GetTilesInRange(range);

        foreach(Tile t in tiles)
        {
            if (!t.opened)
            {
                t.OpenTile(3);
            }
        }
    }
}
