using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{

    public float Speed;
    public float Clockwise = 5.00f;
    public float aClockwise = -5.00f;



    void Start()
    {

    }


    void Update()
    {
        OwlMovement();
        transform.Translate(0, -0.04f ,0);

    }

    void OwlMovement()
    {
        //Movement for going forward and backward for the Owl

        float Horizontal = Input.GetAxis("Horizontal") * -1.0f;
        float Vertical = Input.GetAxis("Vertical") * -1.0f;
       
        Vector3 playerMovement = new Vector3(Horizontal, 0f, Vertical) * Speed * Time.deltaTime;

        transform.Translate(playerMovement, Space.Self);


        //How to elevate the owl

        if(Input.GetKey("space"))
        {
            transform.Translate(0, 0.4f, 0);

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
