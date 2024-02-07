using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class wheelController : MonoBehaviour
{
<<<<<<< HEAD
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
=======
	[SerializeField] float hehespeed;
	public WheelCollider LeftWheel;
	public WheelCollider RightWheel;

	public float curAcceleration;
	public float breakForce;
	private float curBreakForce;
	public float turnAngle = 15f;
	private float currTurn;


	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Space))
			curBreakForce = breakForce;
		else curBreakForce = 0f;

		curAcceleration = hehespeed * Input.GetAxis("Vertical");
		LeftWheel.motorTorque = curAcceleration;

		curAcceleration = hehespeed * Input.GetAxis("Vertical");
		RightWheel.motorTorque = curAcceleration;

		LeftWheel.brakeTorque = curBreakForce;
		RightWheel.brakeTorque = curBreakForce;

		currTurn = turnAngle * Input.GetAxis("Horizontal");
		LeftWheel.steerAngle = currTurn;
		RightWheel.steerAngle = currTurn;
>>>>>>> e05ef8c7255c1a4d1cb50eeff18621d5ece3555b
	}
}
