using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private GameObject spaceShipAudioSourceObject;
    [SerializeField] private string mainMenuSceneName = "StartMenu";
    [SerializeField] private Slider soundSlider;
    [SerializeField] private GameObject player;

    private AudioSource spaceShipAudioSource;
    private bool paused = false;

    void Start()
    {
        pauseCanvas.enabled = false;
        soundSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        spaceShipAudioSource = spaceShipAudioSourceObject.GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        CheckForEscPressed();
    }

    private void CheckForEscPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) { 
                pauseCanvas.enabled = false;
                //player.GetComponentInChildren<FirstPersonAIO>().enabled = true;
                player.GetComponentInChildren<RobotSoundHandler>().enabled = true;
                player.GetComponentInChildren<FirstPersonAIO>().enableCameraMovement = true;
                player.GetComponentInChildren<FirstPersonAIO>().controllerPauseState = false;
                spaceShipAudioSource.Play();
                //soundSlider.value = spaceShipAudioSource.volume;
            }
            else { 
                pauseCanvas.enabled = true;
                //player.GetComponentInChildren<FirstPersonAIO>().enabled = false;
                player.GetComponentInChildren<RobotSoundHandler>().enabled = false;
                player.GetComponentInChildren<FirstPersonAIO>().enableCameraMovement = false;
                player.GetComponentInChildren<FirstPersonAIO>().controllerPauseState = true;
                soundSlider.value = spaceShipAudioSource.volume;
                spaceShipAudioSource.Pause();
            }
            paused = !paused;
        }
    }

    public void OnResumeClick()
    {
        pauseCanvas.enabled = false;
        //player.GetComponentInChildren<FirstPersonAIO>().enabled = true;
        player.GetComponentInChildren<RobotSoundHandler>().enabled = true;
        player.GetComponentInChildren<FirstPersonAIO>().enableCameraMovement = true;
        player.GetComponentInChildren<FirstPersonAIO>().controllerPauseState = false;
        spaceShipAudioSource.Play();
        paused = false;
    }

    public void OnQuitClick()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void ValueChangeCheck()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach(var audioSource in audioSources)
        {
            audioSource.volume = soundSlider.value;
        }
        spaceShipAudioSource.Pause();
    }

}
