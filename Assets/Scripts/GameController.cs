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
    bool mouseDrag = false;

    


    // Use this for initialization
    void Awake () {

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

        //user is currently drawing a barrier 
        if(mouseDrag)
        {
            barriers.Last.Value.GetComponent<Barrier>().setEndPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
		
	}

    private void createBarrier()
    {
        Debug.Log("createBarrier");
        Vector3 startPos = Input.mousePosition;
        mouseDrag = true;
        GameObject newBarrier = Instantiate(barrier, gameObject.transform);
        barriers.AddLast(newBarrier);
        newBarrier.GetComponent<Barrier>().setStartPosition(Camera.main.ScreenToWorldPoint(startPos));
        newBarrier.GetComponent<Barrier>().setEndPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    //Make the target release an item 
    private void shoot()
    {
        target.GetComponent<Source>().shoot(); 
    }

    public void OnMouseDown()
    {
        createBarrier();
    }

    public void OnMouseUp()
    {
        mouseDrag = false;
    }

    /*
    public void OnMouseDrag()
    {
        Debug.Log("mouse drag");
    }
    */
}
