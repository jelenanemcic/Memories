using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSavesForPuzzles : MonoBehaviour
{

    void Start()
    {
        ResetPuzzleSaves();
    }

    private void ResetPuzzleSaves()
    {
        for(int i = 1; i < 10; i++)
        {
            string puzzleName = "puzzle" + i.ToString();
            PlayerPrefs.SetInt(puzzleName, 0);
        }
        
    }
}
