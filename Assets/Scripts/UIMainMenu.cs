using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour {

    GameObject[] levelButtons;
    GameObject[] showOnPause;
    SaveData saveData = new SaveData();

	// Use this for initialization
	void Start () {

        saveData = saveData.ReadFromFile();
        levelButtons = GameObject.FindGameObjectsWithTag("lvlbtn");
        hideButtonGroup(levelButtons);
        showOnPause = GameObject.FindGameObjectsWithTag("showOnPause");
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

    public void Quit()
    {
        saveData.WriteToFile();
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
