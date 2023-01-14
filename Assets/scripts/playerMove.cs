using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    //objects
    public Rigidbody rb;
    public Transform lookTarget;
    public Camera cam;
    
    //privates
    private Vector3 distance;
    private Vector3 jumpForce;
    private Vector3 forward;
    private Vector3 right;
    private bool jumping = false;
    private float timer;
    //publics
    public float movementSpeed;
    public float temp;
    public float jumpHeight;
    public float gravity;
    private float horizontalAxis;
    private float verticalAxis;
    public float jumpTime;
    public float jumpDuration;
    public float startJump;
    public CharacterController controller;


    void Start()
    {
        cam = Camera.main;
        Physics.gravity = new Vector3(0, -gravity, 0);
    }

    void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.transform.LookAt(lookTarget);
        //movement rotation foward and backward

        float angle = (Mathf.Atan2(transform.position.z, transform.position.x)) * Mathf.Rad2Deg + 90f;
        horizontalAxis = movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        verticalAxis = movementSpeed * Input.GetAxis("Vertical")*Time.deltaTime;
        forward = cam.transform.forward;
        right = cam.transform.right;
        forward.y = 0;
        right.y = 0;
 
        forward.Normalize();
        right.Normalize();
        distance = lookTarget.transform.position - transform.position;

        if (Input.GetKey(KeyCode.Space) && Time.time-startJump>jumpTime)
        {
            startJump = Time.time;
        }


        if (!jumping)
        {
            rb.velocity = verticalAxis * forward;
            transform.LookAt(lookTarget);
            transform.RotateAround(lookTarget.transform.position, Vector3.up, -horizontalAxis/distance.magnitude);
        }
        Debug.Log(rb.velocity);
    }

    private void Jump()
    {
        startJump = Time.time;
        jumping = true;
        rb.constraints = RigidbodyConstraints.None;

        
        jumpForce = (horizontalAxis*right* jumpHeight/4 + verticalAxis * forward*jumpHeight/4 + new Vector3(0f, jumpHeight,0f));
        rb.AddForce(jumpForce, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        jumping = false;

    }
}