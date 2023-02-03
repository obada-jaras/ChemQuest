using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float sensitivity = 10f;
    public float speed = 4f;
    public float jumpForce = 50f;
    public float crouchScale = 0.2f;

    private Rigidbody rigidbody;
    private Vector3 standingScale;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        standingScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        LookAroundWithMouse();
        MoveCharcter();
        HandleCrouch();
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

    private void MoveCharcter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = (transform.forward * vertical) + (transform.right * horizontal);
        direction.y = 0f; // exclude the upward component
        direction = direction.normalized * speed * Time.deltaTime;

        transform.position += direction;
    }

    private void LookAroundWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up, mouseX, Space.World);

        transform.RotateAround(transform.position, transform.right, -mouseY);

    }

    private void FixedUpdate()
    {
        // TODO : Fix Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
