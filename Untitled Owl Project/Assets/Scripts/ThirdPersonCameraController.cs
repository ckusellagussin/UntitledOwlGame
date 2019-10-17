using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotationSpeed = 1;
    public Transform targetArea, Owl;
    public float smoothSpeed = 0.125f;
    float xMov, yMov;

    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        targetArea = this.transform.parent;
        Owl = targetArea.transform.parent;

    }


    //Late update so objects being moved can be updated while in the camera without conflict between the object and camera

    void LateUpdate()
    {

        cameraControl();

    }

    void cameraControl()
    {

        //The inputs for what happens when you move the mouse
        xMov += Input.GetAxis("xMov") * rotationSpeed;
        yMov -= Input.GetAxis("yMov") * rotationSpeed;


        //Prevents camera from gliding away from player too much
        yMov = Mathf.Clamp(yMov, -30, 50);

        //Keep Camera focused on the target area
        transform.LookAt(targetArea);      

        //The player will rotate only if right mouse button is held
        if(Input.GetMouseButtonDown(1))
        {
            targetArea.rotation = Quaternion.Euler(yMov, xMov, 0);
            Owl.rotation = Quaternion.Euler(0, xMov, 0);
        }

       else

        {
            targetArea.rotation = Quaternion.Euler(yMov, xMov, 0);
       

        }


    }


}
