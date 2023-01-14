using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyes : MonoBehaviour
{
    public Transform camVis;

    private Vector3 lookDir;
    private float camX;
    private float camY;
    private float angleX;
    private float angleY;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        camX = Input.GetAxis("Mouse X");
        camY = Input.GetAxis("Mouse Y");
        Debug.Log("x "+camX);
        Debug.Log("y " + camY);
        lookDir = new Vector3(camX, camY, 0f);
        angleX = Mathf.Acos(camX);
        angleY = Mathf.Acos(camY);
        Quaternion pepe =  Quaternion.Euler(angleX, angleY, 0f);
        camVis.rotation = pepe;




    }
}
