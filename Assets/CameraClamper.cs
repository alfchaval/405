using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamper : MonoBehaviour {

    //Rotation Sensitivity
    public float RotationSensitivity = 35.0f;
    public float minAngle = -45.0f;
    public float maxAngle = 45.0f;

    //Rotation Value
   public float yRotate = 0.0f;

    // Update is called once per frame
    void Update()
    {

        //Rotate Y view
        yRotate += Input.GetAxis("Mouse Y") * RotationSensitivity * Time.deltaTime;
        yRotate = Mathf.Clamp(yRotate, minAngle, maxAngle);
        transform.eulerAngles = new Vector3(yRotate, 0.0f, 0.0f);
    }
}
