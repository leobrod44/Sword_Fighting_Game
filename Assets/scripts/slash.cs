using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    private Vector3 mousePosI;
    private Vector3 mousePosF;
    private Vector3 slashVec;
    private Transform sword;
    public GameObject trail;
    private TrailRenderer trailRend;
    private Camera cam;
    private Rigidbody rb;
    public float vecbounds;

    public Animator anim;
    private bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        sword = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
        slashVec = Vector3.zero;
        pressed = false;

    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
            {

                mousePosI = cam.ScreenToViewportPoint(Input.mousePosition);
                pressed = true;

            }
            if (Input.GetMouseButtonUp(0) && pressed)
            {

                mousePosF = cam.ScreenToViewportPoint(Input.mousePosition);
                slashVec = mousePosF - mousePosI;
                float angle = Mathf.Atan2(slashVec.y, slashVec.x) * Mathf.Rad2Deg;
                Debug.Log(slashVec);
                //zone 1 bot up
                if ((slashVec.x > -vecbounds && slashVec.x < vecbounds) && slashVec.y > 0)
                {
                    //print("zone 1");
                    anim.SetTrigger("zone 1");
                   
                }
                // zone 2 left right
                else if ((slashVec.x > vecbounds && slashVec.y > 0))
                {
                    //print("zone 2");
                    anim.SetTrigger("zone 2");
                }
                //zone 3
                else if ((slashVec.y > -vecbounds && slashVec.y < vecbounds) && slashVec.x > 0)
                {
                    //print("zone 3");
                    anim.SetTrigger("zone 3");
                }
                // zone 4
                else if ((slashVec.x > vecbounds && slashVec.y < 0))
                {
                    //print("zone 4");
                    anim.SetTrigger("zone 4");
                }
                //zone 5 top bot
                else if ((slashVec.x > -vecbounds && slashVec.x < vecbounds) && slashVec.y < 0)
                {
                    //print("zone 5");
                    anim.SetTrigger("zone 5");
                }
                // zone 6
                else if ((slashVec.x < 0 && slashVec.y < -vecbounds))
                {
                    //print("zone 6");
                    anim.SetTrigger("zone 6");
                }
                //zone 7 right left
                else if ((slashVec.y > -vecbounds && slashVec.y < vecbounds) && slashVec.x < 0)
                {
                    //print("zone 7");
                    anim.SetTrigger("zone 7");
                }
                //zone 8
                else if ((slashVec.x < -vecbounds && slashVec.y > 0))
                {
                    //print("zone 8");
                    anim.SetTrigger("zone 8");
                }
                else
                {
                    print("not registered");
                    
                }
                pressed = false;

            }
        }
}
