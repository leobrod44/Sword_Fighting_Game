using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    
    public Color trailColor = new Color(1, 0, 0.38f);
    public float distanceFromCamera = 5;
    public float startWidth = 0.1f;
    public float endWidth = 0f;
    public float trailTime = 0.24f;
    private bool pressed = false;
    public Vector3 startPos = Vector3.zero;
    public Vector3 finishPos= Vector3.zero;
    private GameObject trailObj;
    Transform trailTransform;
    Camera thisCamera;
    public GameObject clickPoint;
    private GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        thisCamera = Camera.main;
        trailObj = new GameObject("Mouse Trail");
        trailTransform = trailObj.transform;
        trailTransform.position = thisCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
        TrailRenderer trail = trailObj.AddComponent<TrailRenderer>();
        parentObj = GameObject.Find("sword");
        trail.time = -1f;
        trail.time = trailTime;
        trail.startWidth = startWidth;
        trail.endWidth = endWidth;
        trail.numCapVertices = 2;
        trail.sharedMaterial = new Material(Shader.Find("Unlit/Color"));
        trail.sharedMaterial.color = trailColor;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            GameObject spawnPoint = Instantiate(clickPoint);
            spawnPoint.transform.parent = parentObj.transform;
            startPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
            //Debug.Log(clickPoint.transform.parent);
            pressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            finishPos= new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
            pressed = false;
            //Debug.Log("start " + startPos + "finsih " + finishPos);
        }
        if (pressed)
        {
            MoveTrailToCursor(Input.mousePosition);
           
        }
    }

    void MoveTrailToCursor(Vector3 screenPosition)
    {
        trailTransform.position = thisCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, distanceFromCamera));
    }
}
