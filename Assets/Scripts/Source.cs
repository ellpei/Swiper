using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Controls the behavior of the source (aka. cannon) */

public class Source : MonoBehaviour {

    public int timeBetweenShots = 1; //seconds between shots 
    float timer = 0; 
    public GameObject blueberry;
    int shotsfired = 0;
    Vector3 firedirection = new Vector3(1, 1, 0);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if(timer >= timeBetweenShots) {
            shoot();
            timer = 0;
        }
    }

    public void shoot()
    {
        GameObject item = Instantiate(blueberry);
        item.transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        item.GetComponent<Rigidbody>().AddForce(firedirection*300);
    }
}
