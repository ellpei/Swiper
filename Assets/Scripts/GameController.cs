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

        lvl = (int)char.GetNumericValue(SceneManager.GetActiveScene().name[3]);

        lvlinfopath = "Assets/LvlInfo/lvl" + lvl + ".txt";
       
        lvlinfo = LoadLevelInfo(lvl);

        saveData = saveData.ReadFromFile();
        target = GameObject.Find("Target");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool PassedLevel(int points)
    {
        if(lvlinfo == null)
        {
            return false;
        }
        else if(lvlinfo.pointsNeeded < points)
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

        Debug.Log(jsonString);
        return JsonUtility.FromJson<LevelInfo>(jsonString);
    }


}
