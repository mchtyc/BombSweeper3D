using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUIM_BGMovement : MonoBehaviour
{
    public Transform menu;
    public Transform bg_Ground, bg_Trees, bg_Hills01, bg_Hills02, bg_Clouds, bg_Rocks, bg_Sky;
    
    // Update is called once per frame
    void Update()
    {
        DefineBGPosition();
    }

    void DefineBGPosition()
    {
        // TODO: Her yeni dünya eklendiğinde  burası düzenlenmeli

        bg_Ground.position = new Vector3(-menu.position.x * (1f / 1.4f) - 29f, 2f, 20f);
        bg_Trees.position = new Vector3(-menu.position.x * (1f / 1.48f) - 27f, 2f, 20f);
        bg_Hills01.position = new Vector3(-menu.position.x * (1f / 1.67f) - 24f, 2f, 20f);
        bg_Hills02.position = new Vector3(-menu.position.x * (1f / 2f) - 20f, 2f, 20f);
        bg_Clouds.position = new Vector3(-menu.position.x * (1f / 2.86f) - 14f, 2f, 20f);
        bg_Rocks.position = new Vector3(-menu.position.x * (1f / 6.67f) - 6f, 2f, 20f);

    }
}
