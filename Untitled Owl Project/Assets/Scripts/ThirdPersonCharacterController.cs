using UnityEngine;

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


            if(Input.GetKey(KeyCode.Mouse1))
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
   
 
