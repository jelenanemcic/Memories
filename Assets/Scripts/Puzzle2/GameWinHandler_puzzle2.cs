using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinHandler_puzzle2 : MonoBehaviour
{
    [SerializeField] private DragMouse plusSign;
    [SerializeField] private DragMouse sphereSign;
    [SerializeField] private DragMouse cubeSign;

    [SerializeField] private CellController plusCell;
    [SerializeField] private CellController sphereCell;
    [SerializeField] private CellController cubeCell;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            gameOver = CheckGameOver();
            if (gameOver)
            {
                // Play the cutscene

                Debug.Log("Player wins!");
            }
        }
    }

    private bool CheckGameOver()
    {
        bool oneStick = plusSign.transform.position.x == plusCell.transform.position.x && plusSign.transform.position.z == plusCell.transform.position.z;
        bool twoSticks = sphereSign.transform.position.x == sphereCell.transform.position.x && sphereSign.transform.position.z == sphereCell.transform.position.z;
        bool threeSticks = cubeSign.transform.position.x == cubeCell.transform.position.x && cubeSign.transform.position.z == cubeCell.transform.position.z;

        return oneStick && twoSticks && threeSticks;
    }
}
