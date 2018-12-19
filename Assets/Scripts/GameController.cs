using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    public GameObject target;
    public GameObject barrier;
    int lvl;

    private SaveData saveData = new SaveData();



    // Use this for initialization
    void Awake() {

        saveData = saveData.ReadFromFile();
        target = GameObject.Find("Target");

        lvl = (int) char.GetNumericValue(SceneManager.GetActiveScene().name[3]);

        Debug.Log("level: " + lvl);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
