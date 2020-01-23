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
    public float eulrotation = 5f;

    private bool notStunned = true;
    private bool corRunning = false;

    Energy_System energySystem;


    public Rigidbody rb;

    Quaternion bRotation;
    Quaternion eRotation;

    Transform cameraTransform;

    



    void Start()
    {
        cameraTransform = Camera.main.transform;
        energySystem = GetComponent<Energy_System>();
    }

    

    void FixedUpdate()
    {
        OwlMovement();

       

    }

    void OwlMovement()
    {

        //Function is called only if Owl has enough energy to keep going

        if (energySystem.startEnergy <= 0)
        {
            return;
        }

        if (notStunned == true)
        {
          

            

        

        if (Input.GetKey("w"))
            {
                rb.AddRelativeForce(0, 0, currentVelocity * Time.deltaTime, ForceMode.VelocityChange);


                //This is an increment for the Acceleration
                currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);

                energySystem.energyConsumeRate = currentVelocity * 0.1f;
                energySystem.reduceEnergy();

            }

            else
            {
                //subtract from the current velocity while decelerating
                currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
            }

                //Clamped so Owl doesn't go faster than is intended
            currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, maxVelocity);


               // S key slows Owl down if needed
            if (Input.GetKey("s"))
            {
                rb.AddRelativeForce(0, 0, -currentVelocity * Time.deltaTime, ForceMode.VelocityChange);


                if (initialVelocity > minVelocity)
                {
                    initialVelocity -= 1;


                }
            }

            //If right mouse button is held then Owl will face in target direction and keep doing so until it's let go

            if (Input.GetKey(KeyCode.Mouse1))
            {

                bRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);

                eRotation = Quaternion.Euler(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y,
                transform.localEulerAngles.z);


                transform.localRotation = Quaternion.RotateTowards(bRotation, eRotation, eulrotation );
            


            }



            //How to elevate the owl

            if (Input.GetKey("space"))
            {
                rb.AddRelativeForce(0, elevate * Time.deltaTime, 0, ForceMode.VelocityChange);

                energySystem.energyConsumeRate = elevate * 0.1f;
                energySystem.reduceEnergy();

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

  
    //Coroutines for when stun is nolonger in use

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
   
 
