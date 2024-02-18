using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewWheelCollider : XRGrabInteractable
{
	private Rigidbody rb;
	private Vector3 lastHandPosition;

	protected override void Awake()
	{
		base.Awake();
		rb = GetComponent<Rigidbody>();
		rb.maxAngularVelocity = 50f; // Set a maximum angular velocity to prevent unrealistic spinning.
	}

	protected override void OnSelectEntered(SelectEnterEventArgs args)
	{
		base.OnSelectEntered(args);
		rb.angularVelocity = Vector3.zero; // Reset angular velocity when grabbed.
		lastHandPosition = args.interactor.attachTransform.position;
	}

	//protected override void OnSelectHold(XRBaseInteractor interactor)
	//{
	//	base.OnSelectHold(interactor);

	//	float rotationSpeed = 10f; // Adjust the rotation speed as needed.

	//	Vector3 currentHandPosition = interactor.attachTransform.position;
	//	Vector3 handMovement = currentHandPosition - lastHandPosition;

	//	// Calculate rotation input based on hand movement.
	//	float rotationInput = Vector3.Dot(handMovement, transform.up);

	//	// Apply rotation to the wheel.
	//	rb.AddRelativeTorque(Vector3.up * rotationInput * rotationSpeed);

	//	lastHandPosition = currentHandPosition;
	//}
}
