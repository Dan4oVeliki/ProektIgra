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
		// Assuming the XR knob value ranges from 0 to 1
		float knobValue = knob.value;

		// Check if the knob is turned forward (value increased)
		if (knobValue > previousKnobValue)
		{
			// Apply motor torque only when turning forward
			ApplyMotorTorque();
		}

		// Update the previous knob value for the next frame
		previousKnobValue = knobValue;
	}

	private void ApplyMotorTorque()
	{
		// Apply custom motor torque to the wheel collider
		wheelCollider.motorTorque = motorTorque;
	}
}
