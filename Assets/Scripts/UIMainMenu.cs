using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour {

    GameObject[] levelButtons;
    GameObject[] showOnPause;
    SaveData saveData = new SaveData();
    Text highscores;

    // Use this for initialization
    void Awake () {
        highscores = GameObject.Find("highscores").GetComponent<Text>();
        highscores.enabled = false;
        saveData = saveData.ReadFromFile();
        levelButtons = GameObject.FindGameObjectsWithTag("lvlbtn");
        hideButtonGroup(levelButtons);
        showOnPause = GameObject.FindGameObjectsWithTag("showOnPause");
	}

    public void MainMenu()
    {
        hideButtonGroup(levelButtons);
        highscores.enabled = false;
        showButtonGroup(showOnPause);
    }
	

    /*Start the lvl the player left off on last time*/
    public void ResumeGame()
    {
        SceneManager.LoadScene(saveData.lastlevel);
    }

    public void showLevels()
    {
        hideButtonGroup(showOnPause);
        showButtonGroup(levelButtons);
    }

    public void SelectLevel(string lvl)
    {
        saveData.lastlevel = lvl;
    }

    public void HighScores()
    {
        highscores.enabled = true;
        hideButtonGroup(showOnPause);
        List<string[]> scores = saveData.highScores;
        highscores = GameObject.Find("highscores").GetComponent<Text>();
        int num = 1;
        highscores.text = "High Scores: \n";
        foreach(string[] str in scores)
        {
            highscores.text += num + " " + str[0] + " " + str[1] + "\n";
            num++;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    void hideButtonGroup(GameObject[] buttonlist)
    {

        foreach (GameObject g in buttonlist)
        {
            g.SetActive(false);
        }
    }

    public void showButtonGroup(GameObject[] buttonlist)
    {
        foreach (GameObject g in buttonlist)
        {
            g.SetActive(true);
        }
    }
}
