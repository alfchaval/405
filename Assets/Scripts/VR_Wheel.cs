using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Wheel : MonoBehaviour
{
	public float wheelRadio;
	public GameObject hand;
	public bool autoRelease = true;
	public bool canImpulseBackwards = false;
	
	private bool hovered;
	private bool grabbed;
	private bool braked;
	private float currentSpeed = 0;
	private Vector3 lastHandVector;
	
	public event WheelRotated WheelRotation;
	public delegate void WheelRotated(float input);
	
	private void Start()
	{
		if(hand == null)
		{
			this.enabled = false;
		}
	}
	
	private void Update()
	{
		if(autoRelease)
		{
			CheckIfRelease();
		}
		if(!braked)
		{
			if(grabbed)
			{
				ApplyGrabbedMovement();
			}
			else
			{
				ApplyRampImpulse();
				if(hovered)
				{
					ApplyHandImpulse();
				}
			}
		}
	}
	
	public void OnHoverStart()
	{
		if(!grabbed)
		{
			lastHandVector = CalculateHandVector();
			hovered = true;
		}
	}
	
	public void OnHoverEnd()
	{
		if(!grabbed)
		{
			hovered = false;
		}
	}
	
	public void Grab()
	{
		Stop();
		lastHandVector = CalculateHandVector();
		grabbed = true;
	}
	
	public void Release()
	{
		ApplyReleaseForce();
		grabbed = false;
	}
	
	public void Brake(bool b)
	{
		braked = b;
		if(braked)
		{
			Stop();
		}
	}
	
	private void Stop()
	{
		
	}
	
	private void CheckIfRelease()
	{
		//Release the hand if it's too far
	}
	
	private Vector3 CalculateHandVector()
	{
		//return Vector3.ProjectOnPlane((hand.transform.position - this.transform.position), VECTOR NORMAL DE LA RUEDA).normalized;
		return Vector3.zero;
	}
	
	private void ApplyGrabbedMovement()
	{
		
	}
	
	private void ApplyRampImpulse()
	{
		
	}
	
	private void ApplyHandImpulse()
	{
		float impulse = 0;
		//Calculate impulse
		if(impulse > 0 || canImpulseBackwards)
		{
			//Apply
		}
		
	}
	
	private void ApplyReleaseForce()
	{
		
	}
	
	private void RotateWheel()
	{
		
	}
}
