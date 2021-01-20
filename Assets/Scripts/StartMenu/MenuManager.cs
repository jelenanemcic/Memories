using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
	[SerializeField] private string spaceShipSceneName = "Game_Scene_1";
	[SerializeField] private Button resumeButton;

	public static MenuManager am;

	public Canvas menuCanvas;

	void Start()
	{
		if (am == null)
			am = gameObject.GetComponent<MenuManager>();
		CheckForSaves();
	}

	public void BeginGame()
	{
		ClearAllSaves();
		SceneManager.LoadScene(spaceShipSceneName);
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

	private void ClearAllSaves()
    {
		for(int i = 1; i < 10; i++)
        {
			PlayerPrefs.SetInt("puzzle" + i.ToString(), 0);
        }
    }
}
