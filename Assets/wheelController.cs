using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelController : MonoBehaviour
{
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
	}
}
