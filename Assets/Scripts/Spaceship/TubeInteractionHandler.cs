using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TubeInteractionHandler : MonoBehaviour
{
    [SerializeField] private Canvas tubeCanvas;
    [SerializeField] private string endCreditsSceneName = "End_Credits";
    [SerializeField] private int lastPuzzleNumber = 9;

    private string lastPuzzleName;
    private bool puzzleSolved;

    void Start()
    {
        tubeCanvas.enabled = false;
        lastPuzzleName = "puzzle" + lastPuzzleNumber.ToString();

    }

    private void Update()
    {
        puzzleSolved = LoadLastPuzzleSave();
    }

    private bool LoadLastPuzzleSave()
    {
        int save = PlayerPrefs.GetInt(lastPuzzleName, 0);
        if(save == 0) { return false; }
        return true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && puzzleSolved)
        {
            tubeCanvas.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && puzzleSolved)
        {
            SceneManager.LoadScene(endCreditsSceneName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && puzzleSolved)
        {
            tubeCanvas.enabled = false;
        }
    }
}
