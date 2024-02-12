using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Content.Interaction;

public class WheelController : MonoBehaviour
{
	public XRKnob xrKnob;
	private float initialKnobValue;

	// Adjust this value to control the sensitivity of torque applied
	public float torqueMultiplier = 10f;

	// Reference to WheelCollider (attach your wheel collider to this field)
	public WheelCollider wheelCollider;

	private void Start()
	{
		initialKnobValue = xrKnob.value;
	}

	private void Update()
	{
		// Calculate the change in knob value
		float knobDelta = xrKnob.value - initialKnobValue;

		// Apply torque to the wheel collider based on the knob movement
		ApplyWheelTorque(knobDelta * torqueMultiplier);

		// Update initial knob value for the next frame
		initialKnobValue = xrKnob.value;
	}

	private void ApplyWheelTorque(float torque)
	{
		// Apply torque to the WheelCollider here
		// Adjust the wheel collider settings based on your requirements
		wheelCollider.motorTorque = torque;
	}
}
