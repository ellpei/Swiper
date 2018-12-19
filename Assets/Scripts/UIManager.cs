using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    GameObject[] pauseObjects;
    SaveData saveData = new SaveData();
    GameController controller;
    public int score = 0;
    public int lives = 5;
    Text scoreText;
    Text timeText;
    GameObject pausedText;
    GameObject gameInfo;
    GameObject playerName;
    GameObject pauseBtn;

    GameObject mainMenuBtn;

    public int timeCountDown = 40; //time left until lvl ends in seconds
    float timer;
    string timeString = "Time left: ";

    bool gameOver = false;

    // Use this for initialization
    void Start () {

        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "Score: " + score;

        controller = GameObject.Find("controller").GetComponent<GameController>();

        pauseBtn = GameObject.Find("PauseButton");

        playerName = GameObject.Find("InputField");
        playerName.SetActive(false);

        gameInfo = GameObject.Find("GameInfo");
        gameInfo.GetComponent<Text>().text = "You need " + controller.pointsNeeded + " points to pass this level";

        timeText = GameObject.Find("Timer").GetComponent<Text>();
        timeText.text = timeString + timeCountDown;
        Time.timeScale = 1;

        saveData = saveData.ReadFromFile();

        pausedText = GameObject.Find("PausedText");
        mainMenuBtn = GameObject.Find("MainMenu");
        pauseObjects = GameObject.FindGameObjectsWithTag("showOnPause");
        hidePaused();

	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if(timer >= 1)
        {
            timeCountDown--;
            timeText.text = timeString + timeCountDown;
            timer = 0;
        }
        if(timeCountDown <= 0 && !gameOver)
        {
            if(controller.PassedLevel(score))
            {
                LoadNextLevel();
            } else
            {
                gameOver = true;
                GameOver();
            }
        }
		
        if(Input.GetKeyDown(KeyCode.P))
        {
            togglePauseMenu();
        }
	}

    void LoadNextLevel()
    {
        Debug.Log("load next level");
    }

    public void EnterName()
    {
        string name = playerName.GetComponent<InputField>().text;
        Debug.Log("entername");
        string[] highScores = saveData.highScores;
        string temp = "-1";
        for(int i = 0; i < highScores.Length; i++)
        {
            if (temp != "-1")
            {
                string temp2 = highScores[i];
                highScores[i] = temp;
                temp = temp2;
            }
            else
            {
                string thisScore = "";
                if (highScores[i] == "")
                {
                    thisScore = "0";
                }
                else
                {
                    thisScore = highScores[i].Split(' ')[1];
                }
                if (score > Int32.Parse(thisScore))
                {
                    Debug.Log("add to highscores " + i);
                    temp = highScores[i];
                    highScores[i] = name + " " + score;
                }
            }
        }

        saveData.highScores = highScores;
        saveData.WriteToFile();

        Destroy(playerName);
    }
    void GameOver()
    {
        pauseBtn.SetActive(false);
        Time.timeScale = 0;
        pausedText.SetActive(true);
        pausedText.GetComponent<Text>().text = "Game Over :(";

        gameInfo.SetActive(true);
        playerName.SetActive(true);

        mainMenuBtn.SetActive(true);
    }

    /*Pauses the game and shows the pause menu if game is playing. Else, resume the game*/
    public void togglePauseMenu()
    {
        Debug.Log("toggle pause");
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
            pauseBtn.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
            pauseBtn.SetActive(false);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
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
    public void SaveAndQuit()
    {
       // GameController script = controller.GetComponent<GameController>();
        saveData.lives = lives;
        saveData.points = score;
        saveData.lastlevel = SceneManager.GetActiveScene().name;
        saveData.WriteToFile();
        SceneManager.LoadScene("mainMenu");
    }
}
