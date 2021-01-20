using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleFinish : MonoBehaviour
{
    [SerializeField] private string storySceneName = "Story1";
    [SerializeField] private int puzzleNum = 1;
    [SerializeField] private float delay = 1f;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            PlayerPrefs.SetInt("puzzle" + puzzleNum.ToString(), 1);
            StartCoroutine(LoadLevelAfterDelay(delay));
            Debug.Log("Player wins");
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(storySceneName);
    }
}
