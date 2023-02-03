using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    public float moveSpeed = 4f;
    public float jumpForce = 50f;
    public float crouchScale = 0.2f;

    private Rigidbody rigidBody;
    private Vector3 standingScale;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        standingScale = transform.localScale;
    }

    void Update()
    {
        LookAroundWithMouse();
        MoveCharacter();
        HandleCrouch();
    }


    private void LookAroundWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up, mouseX, Space.World);
        transform.RotateAround(transform.position, transform.right, -mouseY);
    }

     private void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = (transform.forward * vertical) + (transform.right * horizontal);
        direction.y = 0f; // exclude the upward component
        direction = direction.normalized * moveSpeed * Time.deltaTime;

        transform.position += direction;
    }

    private void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.C))
        {
            transform.localScale = new Vector3(standingScale.x, standingScale.y * crouchScale, standingScale.z);
        }
        else
        {
            transform.localScale = standingScale;
        }
    }
   
    private void FixedUpdate()
    {
        // TODO : Fix Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * jumpForce);
        }
    }
}
