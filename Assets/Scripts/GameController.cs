using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour, IPointerClickHandler {

	// Use this for initialization
	void Awake () {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        transform.position = Vector2.zero;

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);

        float width = cameraSize.x;
        float height = cameraSize.y;

        collider.size = new Vector2(width, height);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnMouseDown()
    {
        Debug.Log("newtry");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }

    public void OnMouseDrag()
    {
        Debug.Log("mouse drag");
    }

}
