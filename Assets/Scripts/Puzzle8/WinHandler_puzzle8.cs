using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinHandler_puzzle8 : MonoBehaviour
{
    [SerializeField] private MouseDragBoard[] codeNumbers;
    [SerializeField] private FieldController[] codeFields;

    [SerializeField] private string storySceneName = "Story8";
    [SerializeField] private int puzzleNum = 8;
    [SerializeField] private float delay = 0.5f;


    void Update()
    {
        bool isOver = IsOver();
        if (isOver)
        {
            PlayerPrefs.SetInt("puzzle" + puzzleNum.ToString(), 1);
            StartCoroutine(LoadLevelAfterDelay(delay));
            Debug.Log("Player wins!");
        }
    }

    private bool IsOver()
    {
        int i = 0;
        foreach (var number in codeNumbers)
        {
            if (!(number.transform.position.x == codeFields[i].transform.position.x && number.transform.position.z == codeFields[i].transform.position.z))
            {
                return false;
            }
            i += 1;
        }

        return true;
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(storySceneName);
    }
}
