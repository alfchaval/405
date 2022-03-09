using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_WheelChair : MonoBehaviour
{
	public VR_Wheel wheel_L;
	public VR_Wheel wheel_R;
	
	private float axleDistance;
	
	private void Start()
	{
		if(wheel_L != null && wheel_R != null)
		{
			axleDistance = Vector3.Distance(wheel_L.transform.position, wheel_R.transform.position);
			wheel_L.WheelRotation += WheelRotated_L;
			wheel_R.WheelRotation += WheelRotated_R;
		}
	}
	
	private void WheelRotated_L(float input)
	{

	}
	
	private void WheelRotated_R(float input)
	{

	}
	
	private void RotateChair(VR_Wheel wheelRotated, float input, Vector3 rotationCenter)
	{
		transform.RotateAround(rotationCenter, Vector3.up, CalculateRotationAngle(input));
	}
	
	private float CalculateRotationAngle(float input)
	{
		return Mathf.Rad2Deg * input / axleDistance;
	}
}
