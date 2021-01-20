using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleControlsHandler : MonoBehaviour
{
    [SerializeField][Tooltip("float between 0.05-0.25")] private float decreaseFactor = 0.1f;
    [SerializeField][Tooltip("Main menu scene name")] private string mainMenuScene = "Main_menu_scene";
    private AudioSource audioSource;
    private float volume;
    private bool gotItPressed = false;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        volume = audioSource.volume;
    }

    void Update()
    {
        if (gotItPressed)
        {
            if (Input.GetKey(KeyCode.U))
            {
                IncreaseVolume();
            }
            else if (Input.GetKey(KeyCode.L))
            {
                DecreaseVolume();
            }
            else if (Input.GetKey(KeyCode.R))
            {
                ReturnToMainMenu();
            }
        }
    }

    private void DecreaseVolume()
    {
        volume = Mathf.Clamp(volume - decreaseFactor, 0f, 1f);
    }

    private void IncreaseVolume()
    {
        volume = Mathf.Clamp(volume + decreaseFactor, 0f, 1f);
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void OnButtonClick()
    {
        gotItPressed = true;
    }
}
