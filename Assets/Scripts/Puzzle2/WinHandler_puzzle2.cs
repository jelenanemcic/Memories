using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinHandler_puzzle2 : MonoBehaviour
{
    [SerializeField] private MouseDragBoard plusSign;
    [SerializeField] private MouseDragBoard sphereSign;
    [SerializeField] private MouseDragBoard cubeSign;

    [SerializeField] private FieldController plusCell;
    [SerializeField] private FieldController sphereCell;
    [SerializeField] private FieldController cubeCell;

    [SerializeField] private string storySceneName = "Story2";
    [SerializeField] private int puzzleNum = 2;
    [SerializeField] private float delay = 1f;

    private bool gameOver = false;


    void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            gameOver = CheckGameOver();
            if (gameOver)
            {
                //PlayerPrefs.SetInt("puzzle" + puzzleNum.ToString(), 1);
                StartCoroutine(LoadLevelAfterDelay(delay));
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

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(storySceneName);
    }
}
