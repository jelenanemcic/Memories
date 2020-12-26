using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinHandler : MonoBehaviour
{

    [SerializeField] private MouseDragBoard oneStickBoard;
    [SerializeField] private MouseDragBoard twoSticksBoard;
    [SerializeField] private MouseDragBoard threeSticksBoard;

    [SerializeField] private FieldController oneStickField;
    [SerializeField] private FieldController twoSticksField;
    [SerializeField] private FieldController threeSticksField;

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
        bool oneStick = oneStickBoard.transform.position.x == oneStickField.transform.position.x && oneStickBoard.transform.position.z == oneStickField.transform.position.z;
        bool twoSticks = twoSticksBoard.transform.position.x == twoSticksField.transform.position.x && twoSticksBoard.transform.position.z == twoSticksField.transform.position.z;
        bool threeSticks = threeSticksBoard.transform.position.x == threeSticksField.transform.position.x && threeSticksBoard.transform.position.z == threeSticksField.transform.position.z;

        return oneStick && twoSticks && threeSticks;
    }
}
