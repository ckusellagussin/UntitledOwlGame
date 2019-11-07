using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    
    public float initialVelocity = 0.0f;
    public float maxVelocity = 10.0f;
    public float currentVelocity;
    public float accelerationRate = 1.0f;
    public float decelerationRate = 3.0f;
    public float Clockwise = 5.00f;
    public float aClockwise = -5.00f;
    public Rigidbody rb;


    void Start()
    {


    }

    void FixedUpdate()
    {
        OwlMovement();
       

    }

    void OwlMovement()
    {


        if (Input.GetKey("w"))
        {
            rb.AddRelativeForce(0, 0, currentVelocity * Time.deltaTime * -1, ForceMode.VelocityChange);


            //This is an increment 
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
        
        }

        else
                 {
            //subtract from the current velocity while decelerating
                      currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
                  }


            currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, maxVelocity);

    //    if (Input.GetKey("s"))
 //       {
 //           rb.AddRelativeForce(0, 0, initialVelocity * Time.deltaTime * -1, ForceMode.VelocityChange);

      //      if (initialVelocity < maxVelocity)
    //        {
    //            initialVelocity += 1;


    //        }
    
    //    }


        //How to elevate the owl

        if (Input.GetKey("space"))
        {
            rb.AddRelativeForce(0, 20f * Time.deltaTime, 0, ForceMode.VelocityChange);

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
 
