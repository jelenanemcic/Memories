using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinHandler_double_letters_words_puzzle : MonoBehaviour
{
    [SerializeField] private MouseDragBoard[] monoLetters;
    [SerializeField] private MouseDragBoard[] doubleLetters;
    [SerializeField] private FieldController[] monoFields;
    [SerializeField] private FieldController[] doubleFields;

    [SerializeField] private string storySceneName = "Story4";
    [SerializeField] private int puzzleNum = 4;
    [SerializeField] private float delay = 0.5f;

    void Update()
    {
        bool isOver = IsMonoOver() && IsDoubleOver();
        if (isOver)
        {
            //PlayerPrefs.SetInt("puzzle" + puzzleNum.ToString(), 1);
            StartCoroutine(LoadLevelAfterDelay(delay));
            Debug.Log("Player wins!");
        }
    }

    private bool IsMonoOver()
    {
        int i = 0;
        foreach (var letter in monoLetters)
        {
            if (!(letter.transform.position.x == monoFields[i].transform.position.x && letter.transform.position.z == monoFields[i].transform.position.z))
            {
                return false;
            }
            i += 1;
        }

        return true;
    }

    private bool IsDoubleOver()
    {
        // int i = 0;
        foreach(var letter in doubleLetters)
        {
            bool onAny = false;
            foreach(var field in doubleFields)
            {
                if(letter.transform.position.x == field.transform.position.x && letter.transform.position.z == field.transform.position.z)
                {
                    onAny = true;
                    break;
                }
            }
            if (!onAny) { return false; }
        }
        return true;
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(storySceneName);
    }
}
