﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinHandler_puzzle6 : MonoBehaviour
{

    [SerializeField] private MouseDragBoard[] operators;
    [SerializeField] private FieldController[] fields;

    [SerializeField] private string storySceneName = "Story6";
    [SerializeField] private int puzzleNum = 6;
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
        foreach (var oper in operators)
        {
            if (!(oper.transform.position.x == fields[i].transform.position.x && oper.transform.position.z == fields[i].transform.position.z))
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
