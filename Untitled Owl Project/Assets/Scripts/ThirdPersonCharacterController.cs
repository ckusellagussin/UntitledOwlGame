using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThirdPersonCharacterController : MonoBehaviour
{
    
    public float initialVelocity = 0.0f;
    public float maxVelocity = 10.0f;
    public float minVelocity = 0.5f;
    public float upForce = 10.0f;
    public float currentVelocity;
    public float accelerationRate = 1.0f;
    public float decelerationRate = 3.0f;
    public float Clockwise = 5.00f;
    public float aClockwise = -5.00f;
    public float elevate = 15.00f;

    private bool notStunned = true;
    private bool corRunning = false;


    public Rigidbody rb;

    Transform cameraTransform;

    



    void Start()
    {
        cameraTransform = Camera.main.transform;

    }

    void FixedUpdate()
    {
        OwlMovement();
       

    }

    void OwlMovement()
    {

        if (notStunned == true)
        {

            if (Input.GetKey("w"))
            {
                rb.AddRelativeForce(0, 0, currentVelocity * Time.deltaTime, ForceMode.VelocityChange);


                //This is an increment for the Acceleration
                currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);

            }

            else
            {
                //subtract from the current velocity while decelerating
                currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
            }


            currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, maxVelocity);

            if (Input.GetKey("s"))
            {
                rb.AddRelativeForce(0, 0, -currentVelocity * Time.deltaTime, ForceMode.VelocityChange);


                if (initialVelocity > minVelocity)
                {
                    initialVelocity -= 1;


                }
            }


            if (Input.GetKey(KeyCode.Mouse1))
            {

                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                           Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);


            }



            //How to elevate the owl

            if (Input.GetKey("space"))
            {
                rb.AddRelativeForce(0, elevate * Time.deltaTime, 0, ForceMode.VelocityChange);

            }

            //Rotation for the Owl

            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, Time.deltaTime * Clockwise, 0);
            }

            else if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0, Time.deltaTime * aClockwise, 0);

            }

        }



    }

    //This is implemented for when you have been stunned

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            Debug.Log("You have hit a tree");
            if (corRunning) StopCoroutine("movementBack");
            notStunned = false;
            rb.velocity = Vector3.zero;
            StartCoroutine("movementBack");

        }

        if (collision.gameObject.tag =="Branch")
        {
            Debug.Log("You have hit a branch");
            if (corRunning) StopCoroutine("movementBackB");
            notStunned = false;
            rb.velocity = Vector3.zero;
            StartCoroutine("movementBackB");
        }

    }

    IEnumerator movementBack()
    {
        corRunning = true;
        yield return new WaitForSeconds(3);
        notStunned = true;
        corRunning = false;

    }

    IEnumerator movementBackB()
    {
        corRunning = true;
        yield return new WaitForSeconds(1);
        notStunned = true;
        corRunning = false;


    }



      

}
   
 
