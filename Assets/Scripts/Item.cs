using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    Camera cameraRef; 

	// Use this for initialization
	void Start () {
        cameraRef = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(cameraRef.WorldToScreenPoint(transform.position).y < cameraRef.orthographicSize * 2)
        {
            Destroy(gameObject);
        }
	}
}
