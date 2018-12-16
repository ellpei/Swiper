using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Allows user to draw barriers with the mouse */

[RequireComponent(typeof(Camera))]
public class BarrierDrawer : MonoBehaviour {

    private new Camera camera;
    public Material lineMaterial;
    public float lineWidth;
    public float depth = -5;
    bool mouseDrag = false;
    float createTime = 0; 
    GameObject currentBarrier;
    CapsuleCollider capsule;
    public long barrierLifeTime = 5;

    GameController controller; 

    private Vector3? lineStartPoint = null;
    private Vector3 lineEndPoint; 

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        controller = GameObject.Find("controller").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            lineStartPoint = GetMouseCameraPoint();
            mouseDrag = true;

            if (!lineStartPoint.HasValue)
            {
                return;
            }

            lineEndPoint = GetMouseCameraPoint();
            currentBarrier = new GameObject();

            Barrier barScript = currentBarrier.AddComponent<Barrier>();
            barScript.SetLifeLength(barrierLifeTime);

            //make a linerenderer
            var lineRenderer = currentBarrier.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            lineRenderer.SetPositions(new Vector3[2] { lineStartPoint.Value, lineEndPoint });
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;

            //make capsule collider
            capsule = currentBarrier.AddComponent<CapsuleCollider>();
            capsule.radius = lineWidth / 2;
            capsule.center = Vector3.zero;
            capsule.direction = 2;

            controller.AddBarrier(currentBarrier);
            createTime = Time.time; 

        } else if (Input.GetMouseButtonUp(0) && currentBarrier != null)
        {
            currentBarrier.GetComponent<Barrier>().SetLifeLength(barrierLifeTime);
            currentBarrier = null;
            lineStartPoint = null;
            lineEndPoint = Vector3.zero;
            mouseDrag = false;

        } else if(mouseDrag && Time.time - createTime > barrierLifeTime)
        {
            mouseDrag = false;
            createTime = 0;
            currentBarrier = null; 

        } else if (mouseDrag && GetMouseCameraPoint() != lineEndPoint)
        {
            //update the endpoint of line
            lineEndPoint = GetMouseCameraPoint();
            currentBarrier.GetComponent<LineRenderer>().SetPosition(1, lineEndPoint);

            //update capsule height, orientation
            capsule.transform.LookAt(lineStartPoint.Value);
            capsule.transform.position = lineStartPoint.Value + (lineEndPoint - lineStartPoint.Value) / 2;
            capsule.height = (lineEndPoint - lineStartPoint.Value).magnitude;

        }
    }

    private Vector3 GetMouseCameraPoint()
    {
        Vector3 ray = camera.ScreenToWorldPoint(Input.mousePosition);
        ray.z = depth;
        return ray;
    }

}
