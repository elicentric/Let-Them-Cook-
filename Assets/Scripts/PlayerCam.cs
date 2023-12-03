using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation; //stores where the player is facing

    float xRotation;
    float yRotation;

    void Start()     // Start is called before the first frame update
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update() // Update is called once per frame
    {
        //gets mouse input
        //Input.GetAxisRaw(String axisName) gets range either -1, 0, or 1 for an axis. axisNames are specified in project settings
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //note: Unity rotation handles xyz different than Unity's positioning.
        yRotation += mouseX;
        //Mathf is a collection of math functions. Clamp keeps a value between a minimum and maximum float value.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotates cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //rotats camera on x and y rotation
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); //rotates player face

    }
}
