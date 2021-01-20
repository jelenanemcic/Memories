using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HowToPlayMenuManager : MonoBehaviour
{
	[SerializeField, Tooltip("Scene where the game starts.")] 
	private string spaceShipSceneName = "Game_Scene_1";

	[SerializeField, Tooltip("Main menu scene.")]
	private string mainMenuSceneName = "StartMenu";

	public static HowToPlayMenuManager am;

	public Canvas menuCanvas;

	void Start()
	{
		if (am == null)
			am = gameObject.GetComponent<HowToPlayMenuManager>();
	}

	public void BeginGame()
	{
		ClearAllSaves();
		SceneManager.LoadScene(spaceShipSceneName);
	}

	private void ClearAllSaves()
    {
		for(int i = 1; i < 10; i++)
        {
			PlayerPrefs.SetInt("puzzle" + i.ToString(), 0);
        }
    }

	public void BackToMainMenu()
    {
		SceneManager.LoadScene(mainMenuSceneName);
    }
}
