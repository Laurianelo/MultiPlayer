using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Vector3 rotation;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Vector3 rotationCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //player movement
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void RotateLeftAndRight(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateUpAndDown(Vector3 _rotationCamera)
    {
        rotationCamera = _rotationCamera;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    /// <summary>
    /// Player's rotation
    /// Camera rotation 
    /// </summary>
    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        cam.transform.Rotate(-rotationCamera);
    }

    /// <summary>
    /// Player's movement
    /// Check if exist a movement before
    /// </summary>
    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}
