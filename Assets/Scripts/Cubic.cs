using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic : MonoBehaviour
{
    [HideInInspector] public int ID { get; private set; }
    //[HideInInspector] public int LevelCount { get; private set; }
    //[HideInInspector] public bool Open { get; private set; }

    float offset = 2f;
    bool inRange;
    
    void Start()
    {

    }

    void Update()
    {
        //CheckIfInRange();
    }

    void CheckIfInRange()   // NOT finished method, scaling için kullanılacak
    {
        if (inRange)
        {
            if (Mathf.Abs(transform.position.x) > 2f)
            {
                inRange = false;
            }
        }
        else
        {

        }
    }

    public void InitData(int id)
    {
        ID = id;
    }

}
