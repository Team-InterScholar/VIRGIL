//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform target;

    float xRotation;
    float yRotation;

    //private void Start()
    //{
    //   Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}

    private void Update()
    {
        //Mouse Input
        float inputX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float inputY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += inputX;

        xRotation -= inputY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        target.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
