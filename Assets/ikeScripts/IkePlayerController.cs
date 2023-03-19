using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IkePlayerController : MonoBehaviour
{
    public float speed;
    public Transform orientation;
    float inputHorizontalX;
    float inputVerticalY;
    Vector3 moveDirection;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        inputHorizontalX = Input.GetAxisRaw("Horizontal");
        inputVerticalY = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * inputVerticalY + orientation.right * inputHorizontalX;
        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
    }
}
