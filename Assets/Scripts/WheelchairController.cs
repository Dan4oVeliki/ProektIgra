using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class WheelchairController : MonoBehaviour
{
	public XRKnob leftKnob;
	public XRKnob rightKnob;
	public float speed = 5f;
	public float rotationSpeed = 100f;

	private void Update()
	{
		float leftInput = leftKnob.value;
		float rightInput = rightKnob.value;

		// Calculate movement and rotation based on knob inputs
		float forwardSpeed = (leftInput + rightInput) * 0.5f * speed;
		float rotation = (rightInput - leftInput) * rotationSpeed;

		// Apply forces to simulate movement
		Move(forwardSpeed);
		Rotate(rotation);
	}

	private void Move(float forwardSpeed)
	{
		Vector3 forwardForce = transform.forward * forwardSpeed;
		GetComponent<Rigidbody>().AddForce(forwardForce);
	}

	private void Rotate(float rotation)
	{
		transform.Rotate(Vector3.up, rotation * Time.deltaTime);
	}
}