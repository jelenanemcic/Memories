using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{

	public static MenuManager am;

	public Canvas menuCanvas;

	void Start()
	{
		if (am == null)
			am = gameObject.GetComponent<MenuManager>();
	}

	public void BeginGame()
	{
		SceneManager.LoadScene("Game Scene 1");
	}
}
