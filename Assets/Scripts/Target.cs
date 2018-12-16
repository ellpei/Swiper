using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    GameController controller; 

	// Use this for initialization
	void Start () {

        controller = GameObject.Find("Controller").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("register collsion");
        if(collision.gameObject.tag == "projectile")
        {
            Debug.Log("hit target");
            controller.AddPoint();
        }
    }
}
