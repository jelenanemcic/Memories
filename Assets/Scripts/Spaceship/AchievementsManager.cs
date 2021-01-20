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
	public GameObject achievementsPanel;
	private bool opened = false;
	private List<string> achievements = new List<string>();

	void Start()
	{
		if (am == null)
			am = gameObject.GetComponent<AchievementsManager>();

		if (achievementsCanvas)
			achievementsCanvas.enabled = false;

		LoadAchievements();

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
				// achievementsCanvas.GetComponentInChildren<Text>().text = "You currently have no achievements. \n Solve some puzzles to earn them!";
				achievementsPanel.GetComponentInChildren<Text>().text = "You currently have no achievements. \n Solve some puzzles to earn them!";
			}
			else
            {
				string canvasText = "Current Achievements: \n \n";
				int i = 1;
				foreach (string achievement in achievements)
				{
					canvasText += i.ToString() + ".  " + achievement + " solved";
					canvasText += "\n";
					i++;
				}
				achievementsPanel.GetComponentInChildren<Text>().text = canvasText;
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

	private void LoadAchievements()
    {
		for(int i = 1; i < 10; i++)
        {
			int solved = PlayerPrefs.GetInt("puzzle" + i.ToString(), 0);
			if(solved == 1)
            {
				achievements.Add("Puzzle " + i.ToString());
            }
        }
    }
}
