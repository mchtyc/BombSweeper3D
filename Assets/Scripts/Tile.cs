using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public GameObject numberObject, targetObject, frontObject;
    public TextMeshPro numberText;
    public MeshRenderer tileFront, tileBack;
    public Color normalColor, countDownColor, openedColor;
    
    public int number;
    
    public bool unplacable, opened;
    GM_Events gm_Events;

    void Start()
    {
        tileFront.material.color = normalColor;
        gm_Events = GameObject.FindGameObjectWithTag("Managers").GetComponent<GM_Events>();
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
            gm_Events.CallEventGameOver();
        }
        else if (number > 0)
        {
            // Open tile with number
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
            gm_Events.CallEventDecreaseTargetCount();
        }
        else
        {
            // Take Damage      // Damage aldığında damage kadar sayı havada uçuşsun ve cubic sallansın
            //frontObject.SetActive(false);
            tileFront.material.color = openedColor;
            numberObject.SetActive(true);
            numberText.color = Color.red;
            numberText.text = number.ToString();

            gm_Events.CallEventTakeDamage(number, transform.position);
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
