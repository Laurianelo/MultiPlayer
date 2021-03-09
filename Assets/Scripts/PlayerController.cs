using System;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float mouseSensitivity = 3f;

    [SerializeField]
    private PlayerMotor motor;

    private float xMov;
    private float zMov;

    private float yRot;
    private float xRot;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }


    private void Update()
    {
        MovePlayer();

    }

    private void MovePlayer()
    {
        GetInput();
        //calculate velocity
        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);


        //player rotation left and right
        yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotationLF = new Vector3(0, yRot, 0) * mouseSensitivity;
        motor.Rotate(rotationLF);
        /*
        //player rotation up and down
        xRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotationUD = new Vector3(0, xRot, 0) * mouseSensitivity;
        motor.Rotate(rotationUD);*/
    }

    private void RotatePlayer()
    {
     
    }

    private void GetInput()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        zMov = Input.GetAxisRaw("Vertical");
    }
}
