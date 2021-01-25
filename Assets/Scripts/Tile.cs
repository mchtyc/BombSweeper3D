using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Tile : MonoBehaviour
{
    public GameObject numberObject, targetObject, frontObject;
    public TextMeshPro numberText;
    public MeshRenderer tileFront, tileBack;
    public Color normalColor, countDownColor, openedColor;
    //[HideInInspector]
    public int number;
    //[HideInInspector]
    public bool unplacable, opened;
    GM_Events GM_Events;

    private void OnEnable()
    {
        tileFront.material.color = normalColor;
        GM_Events = GameObject.FindGameObjectWithTag("Managers").GetComponent<GM_Events>();
    }

    private void OnDisable()
    {

    }

    private void LateUpdate()
    {
        numberObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        targetObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
    }

    public void ChangeHitColor()
    {
        tileFront.material.color = countDownColor;
    }

    public void OpenTile(int type)
    {
        opened = true;

        if(type == 1)
        {
            SingleTap();
        }
        else if(type == 2)
        {
            DoubleTap();
        }
        else
        {
            if(number == 9)
            {
                DoubleTap();
            }
            else
            {
                SingleTap();
            }
        }
    }

    void SingleTap()
    {
        if (number == 9)
        {
            // Game Over
            frontObject.SetActive(false);
            GM_Events.CallEventGameOver();
        }
        else if (number > 0)
        {
            tileFront.material.color = openedColor;
            numberText.text = number.ToString();
        }
        else
        {
            tileFront.material.color = openedColor;
            OpenNerebyTiles();
        }
    }

    void DoubleTap() 
    {
        if (number == 9)
        {
            // 1 of the targets is found
            frontObject.SetActive(false);
            GM_Events.CallEventDecreaseTargetCount();
        }
        else
        {
            // Take Damage
            frontObject.SetActive(false);
            GM_Events.CallEventTakeDamage(number);
        }
    }

    void OpenNerebyTiles()
    {
        foreach(Tile t in GetNerebyTiles())
        {
            if (!t.opened)
            {
                t.OpenTile(1);
            }
        }
    }

    public void IncreaseNerebyTileNumbers()
    {
        foreach (Tile t in GetNerebyTiles())
        {
            if (t.number != 9)
            {
                t.number++;
            }
        }
    }

    public int MakeAroundUnplacable()
    {
        List<Tile> tiles = GetNerebyTiles();

        foreach (Tile t in tiles)
        {
            t.unplacable = true;
        }

        return tiles.Count;
    }

    List<Tile> GetNerebyTiles()
    {
        List<Tile> nerebyTiles = new List<Tile>();

        foreach (Collider col in Physics.OverlapSphere(transform.position, transform.parent.parent.parent.localScale.x * 2f))
        {
            Tile tile = col.GetComponent<Tile>();

            if (tile != null)
            {
                nerebyTiles.Add(tile);
            }
        }

        return nerebyTiles;
    }

    public List<Tile> GetTilesInRange(float range)
    {
        List<Tile> nerebyTiles = new List<Tile>();

        foreach (Collider col in Physics.OverlapSphere(transform.position, transform.parent.parent.parent.localScale.x * range))
        {
            Tile tile = col.GetComponent<Tile>();

            if (tile != null)
            {
                nerebyTiles.Add(tile);
            }
        }

        return nerebyTiles;
    }

    public void PutTarget()
    {
        number = 9;

        targetObject.SetActive(true);
        numberObject.SetActive(false);

        IncreaseNerebyTileNumbers();
    }
}
