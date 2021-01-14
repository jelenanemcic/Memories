using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotTerminalHandler : MonoBehaviour
{
    [SerializeField] private Canvas terminalCanvas;
    [SerializeField][Tooltip("Number of puzzle between 1 and 9.")] private int numberOfPuzzle = 1;

    void Start()
    {
        terminalCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            terminalCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            terminalCanvas.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Puzzle"+numberOfPuzzle.ToString());
            }
        }
    }
}
