using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler_puzzle5 : MonoBehaviour
{
    [SerializeField] private FieldController[] blueFields;
    [SerializeField] private FieldController[] yellowFields;

    [SerializeField] private MouseDragBoard[] yellowSpheres;
    [SerializeField] private MouseDragBoard[] blueSpheres;


    void Update()
    {
        bool blue = CheckForColor(blueFields, blueSpheres);
        bool yellow = CheckForColor(yellowFields, yellowSpheres);

        bool done = blue && yellow;
        if (done)
        {
            // Play the cutscene
            Debug.Log("Player wins!");
        }

    }

    private bool CheckForColor(FieldController[] fields, MouseDragBoard[] currentSphere)
    {
        // bool done = false;
        foreach(var field in fields)
        {
            bool right = false;
            foreach(var sphere in currentSphere)
            {
                if(CheckIfOnField(field, sphere))
                {
                    right = true;
                    break;
                }
            }
            if (!right)
            {
                return false;
            }
        }

        return true;
    }


    private bool CheckIfOnField(FieldController currentField, MouseDragBoard currentSphere)
    {
        bool onField = currentField.transform.position.x == currentSphere.transform.position.x && currentField.transform.position.z == currentSphere.transform.position.z;
        return onField;
    }

}
