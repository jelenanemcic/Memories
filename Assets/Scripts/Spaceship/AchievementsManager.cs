using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class AchievementsManager : MonoBehaviour
{

	public static AchievementsManager am;

	public Canvas achievementsCanvas;
	public Canvas gameCanvas;
	private bool opened = false;
	private List<string> achievements = new List<string>();

	void Start()
	{
		if (am == null)
			am = gameObject.GetComponent<AchievementsManager>();

		if (achievementsCanvas)
			achievementsCanvas.enabled = false;

		// test
	//	achievements.Add("Puzzle 1");
	//	achievements.Add("Puzzle 2");
	//	achievements.Add("Puzzle 3");
	
	}

	public void openAchievements()
	{
		if (!opened)
        {
			achievementsCanvas.enabled = true;
			gameCanvas.enabled = false;
			opened = true;
			if (achievements.Count == 0) {
				achievementsCanvas.GetComponentInChildren<Text>().text = "You currently have no achievements. \n Solve some puzzles to earn them!";
			}
			else
            {
				string canvasText = "Current Achievements: \n";
				foreach (string achievement in achievements)
				{
					canvasText += achievement;
					canvasText += "\n";
				}
				achievementsCanvas.GetComponentInChildren<Text>().text = canvasText;
			}
		} 
	}

	public void closeAchievements()
    {
		if (opened)
        {
			achievementsCanvas.enabled = false;
			gameCanvas.enabled = true;
			opened = false;
		}
	
	}

	// call when puzzle is successfully solved
	public void addAchievement(string achievement)
    {
		achievements.Add(achievement);
    }
}
