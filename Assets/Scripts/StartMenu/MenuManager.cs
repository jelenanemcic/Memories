using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
	[SerializeField, Tooltip("Scene where the game starts.")] 
	private string spaceShipSceneName = "Game_Scene_1";

	[SerializeField, Tooltip("How to play scene.")]
	private string howToPlaySceneName = "HowToPlay";

	[SerializeField, Tooltip("Resume button.")] 
	private Button resumeButton;

	public static MenuManager am;

	public Canvas menuCanvas;

	void Start()
	{
		if (am == null)
			am = gameObject.GetComponent<MenuManager>();
		CheckForSaves();
	}

	private void CheckForSaves()
    {
		if(PlayerPrefs.GetInt("puzzle1",0) == 0)
        {
			resumeButton.gameObject.SetActive(false);
        }
    }

	public void ResumeButtonClick()
    {
		SceneManager.LoadScene(spaceShipSceneName);
    }

	public void QuitButtonClick()
    {
		Application.Quit();
    }

	public void HowToPlay()
    {
		SceneManager.LoadScene(howToPlaySceneName);
    }
}
