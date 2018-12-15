using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    long lifelength = 10;

    float startTime; 

	// Use this for initialization
	void Start () {

        startTime = Time.time;
	}

    //set the lifetime in seconds
    public void SetLifeLength(long life)
    {
        lifelength = life;
    }

    private void Update()
    {
        if(Time.time >= startTime + lifelength)
        {
            Object.Destroy(gameObject);
        }
    }
}
