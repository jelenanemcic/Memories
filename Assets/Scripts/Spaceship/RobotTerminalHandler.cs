using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotTerminalHandler : MonoBehaviour
{
    [SerializeField] private Canvas terminalCanvas;
    [SerializeField][Tooltip("Number of puzzle between 1 and 9.")] private int numberOfPuzzle = 1;

    private bool puzzleSolved = false;

    void Start()
    {
        terminalCanvas.enabled = false;
        string puzzleName = "puzzle" + numberOfPuzzle.ToString();
        if (PlayerPrefs.GetInt(puzzleName, 0) == 1) { puzzleSolved = true; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !puzzleSolved)
        {
            terminalCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !puzzleSolved)
        {
            terminalCanvas.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !puzzleSolved)
        {
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("Puzzle"+numberOfPuzzle.ToString());
            }
        }
    }
}
