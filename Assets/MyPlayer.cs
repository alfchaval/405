using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MyPlayer : MonoBehaviour
{
    public FixedJoystick MoveJoystick;
    public FixedButton jumpButton;
    public FixedTouchField touchField;
    public Vector3 joy;
    public float joyNormal;
#if UNITY_EDITOR
    public float keyboardInputSpeed = 1;
#endif

    private RigidbodyFirstPersonController fpc;

    private void Start ()
    {
		fpc = GetComponent<RigidbodyFirstPersonController>();
    }
	
	void Update ()
    {
        fpc.RunAxis = MoveJoystick.inputVector;
        fpc.jumpAxis = jumpButton.Pressed;
        fpc.mouseLook.lookAxis = touchField.TouchDist;

        joy = MoveJoystick.inputVector;
        joy.Normalize();

#if UNITY_EDITOR
        Vector2 keyboardInput = new Vector2();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow))
            {
                keyboardInput.y = keyboardInputSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            keyboardInput.y = -keyboardInputSpeed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
            {
                keyboardInput.x = -keyboardInputSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyboardInput.x = keyboardInputSpeed;
        }
        if (keyboardInput.x != 0)
        {
            fpc.RunAxis.x = keyboardInput.x;
        }
        if (keyboardInput.y != 0)
        {
            fpc.RunAxis.y = keyboardInput.y;
        }
        fpc.jumpAxis = fpc.jumpAxis || Input.GetKeyDown(KeyCode.Space);
#endif
    }
}
