using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStoryHandler : MonoBehaviour
{

    [SerializeField] private string spaceShipScene = "Game_Scene_1";
    [SerializeField] private float duration = 30f;

    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(duration));
    }


    private IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(spaceShipScene);
    }
}
