using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotTerminal_withDoorLock : MonoBehaviour
{
    [SerializeField] private Canvas terminalCanvas;
    [SerializeField] [Tooltip("Number of puzzle between 1 and 9.")] private int numberOfPuzzle;
    [SerializeField] private GameObject[] previousRoomDoors;
    [SerializeField] private GameObject previousLights;

    private bool firstTime = true;

    void Start()
    {
        terminalCanvas.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (firstTime)
        {
            firstTime = false;
            CloseTheDoors();
        }

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
                SceneManager.LoadScene("Puzzle" + numberOfPuzzle.ToString());
            }
        }
    }

    private void CloseTheDoors()
    {
        previousLights.SetActive(false);
        foreach(var door in previousRoomDoors)
        {
            door.GetComponent<DoorOpeningHandler>().enabled = false;
            door.GetComponent<Animator>().enabled = false;
        }
    }
}
