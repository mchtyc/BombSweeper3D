using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_Input : MonoBehaviour
{
    public MM_Events MM_Events;
    public GameData gameData;
    public Transform menu;
    public float dragSpeed, idleSpeed, minDrag;

    Cubic currentCubic;
    Vector3 pos1, diff, initialPos, screenCenter;
    bool moving;
    int selectedWorld;

    void Start()
    {
        screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, -40f);
        selectedWorld = gameData.GetLastOpenedWorld();
        currentCubic = DefineSelectedCube(screenCenter);
        currentCubic.StartAnimation();
    }

    void LateUpdate()
    {
        if(MM_Enums.GetMenuPage() == MenuPage.WorldPage)
        {
            GetInput();
        }
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            pos1 = initialPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            diff = Input.mousePosition - pos1;
            pos1 = Input.mousePosition;

            if(!moving && Mathf.Abs(initialPos.x - Input.mousePosition.x) > minDrag)
            {
                if(currentCubic != null)
                {
                    currentCubic.StopAnimation();
                }
                
                moving = true;
                selectedWorld = 0;
                MM_Events.CallEventWorldUnfocus();
            }

            if(moving) 
            {
                menu.Translate(diff.x * dragSpeed, 0f, 0f);

                RestrictPositions(); 
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if(!moving)
            {
                Cubic cubic = DefineSelectedCube(Input.mousePosition);
                
                if (cubic != null && cubic.ID == selectedWorld)
                {
                    StartCoroutine(WorldPressAnimation(cubic.gameObject.transform));
                    OpenCubic(cubic.ID);
                }
            }
            else
            {
                StartCoroutine(DragCubics(diff.x));
            }
        }
    }

    IEnumerator WorldPressAnimation(Transform world)
    {
        for(int i = -4; i < 4; i++)
        {
            float scaleFactor = i / 40f;
            world.localScale = world.localScale - new Vector3(scaleFactor, scaleFactor, scaleFactor);
            yield return null;
        }
    }

    IEnumerator DragCubics(float speed)
    {
        for (int i = 5; i > 0; i--) { 
            menu.position = new Vector3(menu.position.x + (speed * idleSpeed), 0f, 0f);
            speed /= 2;
            RestrictPositions();
            yield return null;
        }

        StartCoroutine(FinalPositioning());
    }

    IEnumerator FinalPositioning()
    {
        float finalX = defineFinalPosX();
        
        for (int i = 0; i < 10; i++)
        {
            menu.position = new Vector3(Mathf.Lerp(menu.position.x, finalX, (float)i / 10f), 0f, 0f);
            yield return null;
        }

        currentCubic = DefineSelectedCube(screenCenter);
        if(currentCubic != null)
        {
            currentCubic.StartAnimation();
        }
        
        moving = false;
        MM_Events.CallEventWorldOnFocus(selectedWorld);
    }

    void RestrictPositions()
    {
        if (menu.position.x > 5f)
        {
            menu.position = new Vector3(5f, 0f, 0f);
        }
        else if (menu.position.x < -85f)
        {
            menu.position = new Vector3(-85f, 0f, 0f);
        }
    }

    float defineFinalPosX()
    {
        // Buralar world sayısına göre dinamik olmalı
        float menuPosX = menu.position.x, finalValue;

        if (menuPosX > -10f)
        {
            finalValue = 0f;
            selectedWorld = 1;
        }
        else if (menuPosX > -30f)
        {
            finalValue = -20f;
            selectedWorld = 2;
        }
        else if (menuPosX > -50f)
        {
            finalValue = -40f;
            selectedWorld = 3;
        }
        else if (menuPosX > -70f)
        {
            finalValue = -60f;
            selectedWorld = 4;
        }
        else
        {
            finalValue = -80f;
            selectedWorld = 5;
        }

        return finalValue;
    }

    Cubic DefineSelectedCube(Vector3 coordinate)
    {
        Ray ray = Camera.main.ScreenPointToRay(coordinate);
        RaycastHit hit;
        bool isDetected = false;

        if (Physics.Raycast(ray, out hit, 60f))
        {
            if (hit.collider.GetComponent<Cubic>())
            {
                isDetected = true;
            }
        }

        if (isDetected)
        {
            return hit.collider.GetComponent<Cubic>();
        }
        else
        {
            return null;
        }
    }

    void OpenCubic(int id)
    {
        MM_Events.CallEventSelectCubic(id);
    }
}
