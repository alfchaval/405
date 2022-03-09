using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraMovement : MonoBehaviour
{
    public float forwardSpeed = 2;
    public float lateralSpeed = 2;
    public float rotationSpeed = 50;

    private void Update()
    {
        transform.position -= transform.forward * Input.GetAxis("L_Vertical") * forwardSpeed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("L_Horizontal") * lateralSpeed * Time.deltaTime;
        transform.Rotate(Input.GetAxis("R_Vertical") * rotationSpeed * Time.deltaTime, 0, 0);
        transform.Rotate(0, Input.GetAxis("R_Horizontal") * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(0, 0, Input.GetAxis("LB_RotateLeft") * rotationSpeed * Time.deltaTime);
        transform.Rotate(0, 0, -Input.GetAxis("RB_RotateRight") * rotationSpeed * Time.deltaTime);
    }
}