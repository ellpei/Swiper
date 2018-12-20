using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    UIManager UIManager;

	// Use this for initialization
	void Start () {

        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "projectile")
        {
            UIManager.AddScore();
        }
    }

}
