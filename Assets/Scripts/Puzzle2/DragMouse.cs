using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class DragMouse : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private CellController[] cells;
    [SerializeField] private CellController currentCell;
    [SerializeField] private float yHeight;


    private void Start()
    {
        cells = FindObjectsOfType<CellController>();
    }


    private void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

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

        transform.position = GetMouseAsWorldPoint() + mOffset;

    }

    private void OnMouseExit()
    {
        //if (Input.GetMouseButtonUp(0))
        {
            // Debug.Log(gameObject.transform.position.ToString());
            float minDistance = 0f;
            currentCell.SetIsFree(true);
            foreach (var cell in cells)
            {
                if (cell.GetIsFree())
                {
                    float currentDistance = CalculateDistance(gameObject.transform, cell.transform);
                    if (minDistance == 0 || currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        currentCell = cell;
                    }
                }
            }
            currentCell.SetIsFree(false);
            gameObject.transform.position = new Vector3(currentCell.transform.position.x, yHeight, currentCell.transform.position.z);
        }
    }

    private float CalculateDistance(Transform tf1, Transform tf2)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(tf1.position.x - tf2.position.x,2)+ Mathf.Pow(tf1.position.y - tf2.position.y, 2));

        return distance;
    }


}
