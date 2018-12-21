using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;

public class GameController : MonoBehaviour {

    public LevelInfo lvlinfo;
    string lvlinfopath;

    public GameObject target;
    public GameObject barrier;
    public int lvl;


    private SaveData saveData = new SaveData();

    // Use this for initialization
    void Awake() {

        saveData = saveData.ReadFromFile();
        target = GameObject.Find("Target");

        lvl = (int) char.GetNumericValue(SceneManager.GetActiveScene().name[3]);

        lvlinfopath = "Assets/LvlInfo/lvl" + lvl + ".txt";

        lvlinfo = LoadLevelInfo(lvl);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool PassedLevel(int points)
    {
        if(lvlinfo.pointsNeeded < points)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private LevelInfo LoadLevelInfo(int lvl)
    {
        StreamReader streamreader = File.OpenText(lvlinfopath);
        string jsonString = streamreader.ReadToEnd();

        return JsonUtility.FromJson<LevelInfo>(jsonString);
    }


}
