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
        //destroy self if fallen out of camera range
        if (cameraRef.WorldToScreenPoint(transform.position).y < cameraRef.orthographicSize * 2)
        {
            StartCoroutine(DelayedDestruction(5));
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Target")
        {
            StartCoroutine(DelayedDestruction(5));
        }
    }

    public IEnumerator DelayedDestruction(int seconds)
    {
        Destroy(gameObject.GetComponent<Renderer>());
        Destroy(gameObject.GetComponent<Rigidbody>());
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

}
