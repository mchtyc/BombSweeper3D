using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Input : MonoBehaviour
{
    public GM_Events GM_Events;
    public GM_Board GM_Board;
    public GM_Boosters GM_Boosters;
    public Transform Shape;

    public float zoomSpeed, minScale, minTurnAngle,turnSpeed, rotateSpeed;

    Tile activeTile;
    bool isFirstHit, isSingleTouch = true, rotating;
    float touchDiff1;
    Vector3 prevMousePos, initialMousePos, shapePos, playgroundPos;

    private void OnEnable()
    {
        GM_Events.EventCountDownFinished += OnCountDownFinished;
    }

    private void Start()
    {
        Shape = GameObject.FindGameObjectWithTag("Cubic").transform;
        shapePos = Shape.position;
        playgroundPos = Shape.parent.position;
    }

    private void OnDisable()
    {
        GM_Events.EventCountDownFinished -= OnCountDownFinished;
    }

    // Update is called once per frame
    void LateUpdate()
    {
#if UNITY_EDITOR
        OneFinger();
#endif
        
        if (Input.touchCount == 1)
        {
            if (isSingleTouch)
            {
                OneFinger();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isSingleTouch = true;
            }
        }
        else if (Input.touchCount == 2)
        {
            isSingleTouch = false;
            TwoFingers();
        }

        if (Shape.parent.position != playgroundPos || Shape.position != shapePos)
        {
            Shape.parent.position = playgroundPos;
            Shape.position = shapePos;
        }
    }

    void OneFinger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prevMousePos = initialMousePos = Input.mousePosition;
            rotating = false;
        }

        if (Input.GetMouseButton(0))
        {
            float distance = (Input.mousePosition - initialMousePos).magnitude;

            if (distance >= Screen.width / 20f)
            {
                rotating = true;
                RotateCubic();
            }
        }

        if (Input.GetMouseButtonUp(0) && !rotating)
        {
            Tile selectedTile = CheckHit();

            if (selectedTile != null)
            {
                if (GM_Enums.GetGameState() == GameStates.Clickable)
                {
                    if (GM_Enums.GetGamePhase() == GamePhases.FirstSelection)
                    {
                        FirstSelection(selectedTile);
                    }
                    else if (GM_Enums.GetGamePhase() == GamePhases.Started)
                    {
                        TileOpenableCheck(selectedTile);
                    }
                }
                else if(GM_Enums.GetGameState() == GameStates.Booster)
                {
                    GM_Boosters.InstantiateBooster(selectedTile);
                }
            }
        }
    }
    
    void TwoFingers()
    {
        Touch t1 = Input.touches[0];
        Touch t2 = Input.touches[1];

        //Vector3 t1Pos = Vector3.zero, t2Pos = Vector3.zero;
        //float touchDiff1 = 0f;

        if (t2.phase == TouchPhase.Began)
        {
            touchDiff1 = Vector2.Distance(t1.position, t2.position);
        }
        else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
        {
            float touchDiff2 = Vector2.Distance(t1.position, t2.position);

            float d = (touchDiff2 - touchDiff1) * zoomSpeed;
            Debug.Log("Zooming: " + touchDiff2 + " - " + touchDiff1 + " = " + d);

            if (Mathf.Abs(touchDiff2 - touchDiff1) > minScale)
            {
                Shape.parent.localScale += new Vector3(d, d, d);

                // Clamping scale between 0.2f and 2f
                if (Shape.parent.localScale.x > 2f)
                {
                    Shape.parent.localScale = new Vector3(2f, 2f, 2f);
                }
                else if (Shape.parent.localScale.x < 0.2f)
                {
                    Shape.parent.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
            }

            touchDiff1 = touchDiff2;

            float turnAngle = Angle(t1.position, t2.position);
            float prevTurnAngle = Angle(t1.position - t1.deltaPosition, t2.position - t2.deltaPosition);
            float turnAngleDelta = Mathf.DeltaAngle(prevTurnAngle, turnAngle);
            
            if (Mathf.Abs(turnAngleDelta) > minTurnAngle)
            {
                turnAngleDelta *= turnSpeed;

                Vector3 rotationDeg = Vector3.zero;
                rotationDeg.z = turnAngleDelta;
                Shape.parent.rotation *= Quaternion.Euler(rotationDeg);
            }
        }
    }

    void TileOpenableCheck(Tile t)
    {
        if (!t.opened)
        {
            if (!isFirstHit)
            {
                FirstHit(t);
            }
            else
            {
                SecondHit(t);
            }
        }
    }

    private void FirstHit(Tile t)
    {
        isFirstHit = true;
        t.ChangeHitColor();
        GM_Events.CallEventTileFirstHit();
        activeTile = t;
    }

    private void SecondHit(Tile t)
    {
        if (t == activeTile)
        {
            t.OpenTile(2);
            GM_Events.CallEventTileSecondHit();
            isFirstHit = false;
            activeTile = null;
        }
    }

    private void FirstSelection(Tile t)
    {
        GM_Board.SetupBoard(t);
        GM_Enums.ChangeGamePhase(GamePhases.Started);
    }

    Tile CheckHit()
    {
        Tile t;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.CompareTag("Tile"))
            {
                t = hit.transform.GetComponent<Tile>();
                return t;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        } 
    }

    public void OnCountDownFinished()
    {
        activeTile.OpenTile(1);
        activeTile = null;
        isFirstHit = false;
    }

    float Angle(Vector2 pos1, Vector2 pos2)
    {
        Vector2 from = pos2 - pos1;
        Vector2 to = new Vector2(1, 0);

        float result = Vector2.Angle(from, to);
        Vector3 cross = Vector3.Cross(from, to);

        if (cross.z > 0)
        {
            result = 360f - result;
        }

        return result;
    }

    void RotateCubic()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(prevMousePos) - Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
        Shape.parent.RotateAround(Shape.GetChild(0).position, Vector3.up, difference.x * rotateSpeed);
        Shape.parent.RotateAround(Shape.GetChild(0).position, Vector3.right, -difference.y * rotateSpeed);

        prevMousePos = Input.mousePosition;
    }
}