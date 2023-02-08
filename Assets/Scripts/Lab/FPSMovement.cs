using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float mouseSensitivity = 15f;
    private float minimumVertical = -60f;
    private float moveSpeed = 4f;
    private float jumpForce = 50f;
    private float crouchScale = 0.2f;

    private Rigidbody rigidBody;
    private Vector3 standingScale;

    private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    private RotationAxes axes;
    private float sensitivityX;
    private float sensitivityY;
    private float minimumY;
    private float maximumY;
    private float rotationY;

    private void Start()
    {
        Cursor.visible = false;

        standingScale = transform.localScale;
        
        // Make the rigid body not change rotation
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;

        axes = RotationAxes.MouseXAndY;
        sensitivityX = mouseSensitivity;
        sensitivityY = mouseSensitivity;
        minimumY = minimumVertical;
        maximumY = -minimumVertical;
        rotationY = 0f;
    }

    void Update()
    {
        LookAroundWithMouse();
        MoveCharacter();
        HandleCrouch();
    }


    private void LookAroundWithMouse()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
            
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
            
            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    private void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = (transform.forward * vertical) + (transform.right * horizontal);
        direction.y = 0f; // exclude the upward component
        direction = direction.normalized * moveSpeed * Time.deltaTime;

        Vector3 nextPosition = transform.position + direction;

        // Check for collision with the wall
        RaycastHit hit;
        if (Physics.Linecast(transform.position, nextPosition, out hit))
        {
            // If there is a collision with a door, ignore it and continue moving
            if (hit.transform.CompareTag("door"))
            {
                transform.position = nextPosition;
                return;
            }

            // If there is a collision with a wall, return the player a little to the back
            transform.position = hit.point - (direction.normalized * 0.01f);
            return;
        }

        transform.position = nextPosition;
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
}
