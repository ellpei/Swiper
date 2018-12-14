using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    Vector3 startPos;
    Vector3 endPos; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setStartPosition(Vector3 position)
    {
        startPos = position;
        startPos.z = -5;
        transform.position = startPos;
    }
    public void setEndPosition(Vector3 position)
    {
        Debug.Log("set endpos");
        endPos = position;

        //change the length of the barrier 
        transform.localScale = new Vector3(100*endPos.x, transform.localScale.y, 1);
        //change the rotation of the barrier 
        transform.RotateAround(startPos, Mathf.Tan(Mathf.Abs(startPos.y-endPos.y) / Mathf.Abs(startPos.x - endPos.x)));
    }

    public void changeLength(int len)
    {

    }
}
