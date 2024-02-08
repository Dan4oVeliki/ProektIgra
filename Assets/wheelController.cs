using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class wheelController : MonoBehaviour
{
	public XRKnob knob; // Reference to your XR knob
	public WheelCollider wheelCollider;
	public float motorTorque = 1000f;

	private float previousKnobValue = 0f;
	private void Start()
	{
		previousKnobValue = knob.value;
	}

	private void Update()
	{
		float knobValue = knob.value;
		if (knobValue > previousKnobValue)
		{
			ApplyMotorTorque();
		}
		previousKnobValue = knobValue;
	}

	private void ApplyMotorTorque()
	{
		// Apply custom motor torque to the wheel collider
		wheelCollider.motorTorque = motorTorque;
	}
}
