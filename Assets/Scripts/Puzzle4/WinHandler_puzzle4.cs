using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler_puzzle4 : MonoBehaviour
{
    [SerializeField] private MouseDragBoard[] letters;
    [SerializeField] private FieldController[] fields;

    void Update()
    {
        bool isOver = IsOver();
        if (isOver)
        {
            // Play the cutscene
            Debug.Log("Player wins!");
        }
    }

    private bool IsOver()
    {
        int i = 0;
        foreach(var letter in letters)
        {
            if(!(letter.transform.position.x == fields[i].transform.position.x && letter.transform.position.z == fields[i].transform.position.z))
            {
                return false;
            }
            i += 1;
        }

        return true;
    }
}
