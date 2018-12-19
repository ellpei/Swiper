using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    GameObject[] pauseObjects;
    SaveData saveData = new SaveData();

	// Use this for initialization
	void Start () {

        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("showOnPause");
        hidePaused();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.P))
        {
            togglePauseMenu();
        }

	}

    /*Pauses the game and shows the pause menu if game is playing. Else, resume the game*/
    public void togglePauseMenu()
    {
        Debug.Log("toggle pause");
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void hidePaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    public void showPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //Loads inputted level 
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
