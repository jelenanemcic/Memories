using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragBoard : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private FieldController[] cells;
    private StartGameHandler startGameHandler;
    private bool gotItPressed = false;
    [SerializeField] private FieldController currentCell;
    [SerializeField] private float yHeight = 0.1f;



    private void Start()
    {
        cells = FindObjectsOfType<FieldController>();
        startGameHandler = FindObjectOfType<StartGameHandler>();
        Cursor.visible = true;
    }


    private void Update()
    {
        gotItPressed = startGameHandler.GetGotIsPressed();
    }

    private void OnMouseDown()

    {
        if (gotItPressed)
        {
            mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



            // Store offset = gameobject world pos - mouse world pos

            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    private void OnMouseDrag()

    {
        if (gotItPressed)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }

    }

    private float CalculateDistance(Transform tf1, Transform tf2)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(tf1.position.x - tf2.position.x, 2) + Mathf.Pow(tf1.position.z - tf2.position.z, 2));

        return distance;
    }

    private void OnMouseExit()
    {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            MoveToClosest();
        }
    }

    private void MoveToClosest()
    {
        
        
        float minDistance = 0f;
        bool firstPass = true;
        currentCell.SetIsFree(true);
        Transform currentTf = gameObject.transform;
        foreach (FieldController cell in cells)
        {
            if (cell.GetIsFree())
            {
                float currentDistance = CalculateDistance(currentTf, cell.transform);
                if (firstPass || currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    currentCell = cell;
                }
                firstPass = false;
            }
        }
        currentCell.SetIsFree(false);
        gameObject.transform.position = new Vector3(currentCell.transform.position.x, yHeight, currentCell.transform.position.z);
        
    }
}
