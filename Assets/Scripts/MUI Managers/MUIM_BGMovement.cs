using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUIM_BGMovement : MonoBehaviour
{
    public Transform BG, menu;
    
    // Update is called once per frame
    void Update()
    {
        DefineBGPosition();
    }

    void DefineBGPosition()
    {
        // TODO: Her yeni dünya eklendiğinde  burası düzenlenmeli
        BG.position = new Vector3(-menu.position.x * (1f / 5f) - 8f, 2f, 20f);
    }
}
