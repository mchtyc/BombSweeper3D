using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataFlow : MonoBehaviour
{
    public int cubicIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    /*
     * Infos to be passed to GameScene
     * 
     *  Cubic prefab
     *  Duration
     *  Difficulty
     *  Target count (Difficulty ile belirlenebilir)
     *  
     */
}
