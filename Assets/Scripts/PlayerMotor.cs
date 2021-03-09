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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
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
