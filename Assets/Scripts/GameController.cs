using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour {

    public LinkedList<GameObject> barriers = new LinkedList<GameObject>();
    public LinkedList<Item> items = new LinkedList<Item>();
    public GameObject target;
    public GameObject source;
    public GameObject barrier;
    public int points = 0;
    public int lives = 5;

    private SaveData saveData = new SaveData();


    // Use this for initialization
    void Awake () {

        saveData = saveData.ReadFromFile();
        //cover the canvas with the box collider in order to register mouse events 
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        transform.position = Vector2.zero;

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);

        float width = cameraSize.x;
        float height = cameraSize.y;

        collider.size = new Vector2(width, height);

        target = GameObject.Find("Target");
        source = GameObject.Find("Cannon");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Make the target release an item 
    private void shoot()
    {
        target.GetComponent<Source>().shoot(); 
    }

    public void AddBarrier(GameObject barr)
    {
        barriers.AddLast(barr);
    }

    public void AddPoint()
    {
        points++;
    }
}
