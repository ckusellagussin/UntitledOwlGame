using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedThirdPersonCamera : MonoBehaviour
{

    public float mouseSensitivity = 10;
    public Transform targetObject;
    public float camToTarget = 5;
    public float smoothRotationDuration = 1.2f;

    public Vector2 camClamp = new Vector2(-40, 60);

    public Vector3 smoothRotationSpeed;
    public Vector3 initialRotation;

    float horizontal;
    float vertical;


    // Start is called before the first frame update
    void Start()
    {
        //So Cursor is not shown
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;


    }

    // Update is called after all other update methods
    void LateUpdate()
    {
        //Input for the Camera
        horizontal += Input.GetAxis("yMov") * mouseSensitivity * -1;
        vertical -= Input.GetAxis("xMov") * mouseSensitivity * -1;

        //So Camera won't overlap the Owl
        horizontal = Mathf.Clamp(horizontal, camClamp.x, camClamp.y);


        //Smooths the camera when rotating the camera so it's not so fast and what happens when input conditions are met
        initialRotation = Vector3.SmoothDamp(initialRotation, new Vector3(horizontal, vertical), ref smoothRotationSpeed, smoothRotationDuration);
        

        //Camera rotations through angles
        transform.localEulerAngles = initialRotation;
        

        //How far away the camera will be from the Owl
        transform.position = targetObject.position - (transform.forward * camToTarget);

    }
}
