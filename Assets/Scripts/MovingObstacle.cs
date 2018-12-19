using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Script for creating moving obstacles*/
public class MovingObstacle : MonoBehaviour {

    public float lowerBound;
    public float upperBound;
    private bool movingUp = false;
    float moveSpeed = 0.15f;

	// Use this for initialization
	void Start () {

        lowerBound = -Camera.main.orthographicSize + gameObject.GetComponent<BoxCollider>().size.x;
        upperBound = Camera.main.orthographicSize - gameObject.GetComponent<BoxCollider>().size.x;
        transform.position = new Vector3(transform.position.x, transform.position.y, -5);

	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.y <= lowerBound)
        {
            movingUp = true;
        } else if(transform.position.y >= upperBound)
        {
            movingUp = false;
        }

        if(!movingUp)
        {
            //move downwards 
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed, transform.position.z);
        }
        else if(movingUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed, transform.position.z);
        }

    }
}
