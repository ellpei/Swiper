using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Controls the behavior of the source (aka. cannon) */

public class Source : MonoBehaviour {

    public int timeBetweenShots = 1; //seconds between shots 
    int bombrate;
    bool rotating = false;

    float timer = 0; 
    public GameObject blueberry;
    Vector3 firedirection;
    Transform nosslePos;

    GameController controller;

    float maxrotationZ;
    float minrotationZ;
    bool increasingRotation = false;

	// Use this for initialization
	void Start () {

        maxrotationZ = -0.38f;
        minrotationZ = -0.92f;

        controller = GameObject.Find("controller").GetComponent<GameController>();
        nosslePos = GameObject.Find("Nossle").GetComponent<Transform>();
        firedirection = nosslePos.position - transform.position;

        bombrate = controller.lvlinfo.bombrate;

        if (controller.lvl == 2)
        {
            rotating = true; 
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (rotating)
        {
            if (transform.rotation.z >= maxrotationZ)
            {
                increasingRotation = false;
            }
            else if (transform.rotation.z <= minrotationZ)
            {
                increasingRotation = true;
            }
            if(increasingRotation)
            {
                transform.Rotate(new Vector3(0, 0, 1), 1);
            } else
            {
                transform.Rotate(new Vector3(0, 0, 1), -1);
            }
        }

        timer += Time.deltaTime;
        if(timer >= timeBetweenShots) {
            shoot();
            timer = 0;
        }
    }

    public void shoot()
    {
        GameObject item = Instantiate(blueberry);
        item.transform.position = new Vector3(nosslePos.position.x, nosslePos.position.y, -5);

        firedirection = nosslePos.position - transform.position;
        item.GetComponent<Rigidbody>().AddForce(firedirection*300);
    }
}
