using System;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float mouseSensitivityX = 3f;

    [SerializeField]
    private float mouseSensitivityY = 3f;

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

        RotatePlayer();
    }

    private void RotatePlayer()
    {
        //player rotation left and right 
        Vector3 rotationLR = new Vector3(0, yRot, 0) * mouseSensitivityX;
        motor.RotateLeftAndRight(rotationLR);

        //player rotation up and down (camera
        Vector3 rotationUD = new Vector3(xRot, 0, 0) * mouseSensitivityY;
        motor.RotateUpAndDown(rotationUD);
    }

    private void GetInput()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        zMov = Input.GetAxisRaw("Vertical");

        yRot = Input.GetAxisRaw("Mouse X");
        xRot = Input.GetAxisRaw("Mouse Y");
    }
}
