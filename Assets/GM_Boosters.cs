using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Boosters : MonoBehaviour
{
    public GM_Events GM_Events;
    GameObject _booster;
    
    public void InstantiateBooster(Tile t)
    {
        if (!t.opened)
        {
            Booster booster = Instantiate(_booster, t.transform.position, Quaternion.identity).GetComponent<Booster>();
            booster.GetTile(t);
            GM_Enums.ChangeGameState(GameStates.Clickable);
        }
    }   
    
    public void OnClickBoosterBtn(GameObject booster)
    {
        GM_Enums.ChangeGameState(GameStates.Booster);

        GM_Events.CallEventBoosterUtility(booster);
        _booster = booster;
    }   
}
