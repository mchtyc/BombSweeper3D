using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public BoosterData boosterData;
    protected Tile selectedTile;
    protected float range;

    void Start()
    {
        InitialState();
    }

    public void GetTile(Tile t)
    {
        selectedTile = t;
    }

    protected virtual void InitialState()
    {
        transform.Translate(0f, 0f, -0.5f, selectedTile.transform);
        StartCoroutine(Detonate());
    }

    protected virtual IEnumerator Detonate()
    {
        yield return null;
    }
}
