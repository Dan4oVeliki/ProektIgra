using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class NewestWheel : XRBaseInteractable
{
	[SerializeField] private Transform wheelTransform;
	[SerializeField] private Rigidbody attachedRigidbody;
	[SerializeField] private float movementForce = 10f; // Adjust this value as needed
	[SerializeField] private float rotationForce = 5f; // Adjust this value as needed
	[SerializeField] GameObject centerObject; // Reference to the center object
	public UnityEvent<float> OnWheelRotated;


	private float currentAngle = 0.0f;
	private float angularVelocity = 0.0f;
	private bool isRotating = false;
	private float inertiaDampingFactor = 0.98f;

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void OnSelectEntered(SelectEnterEventArgs args)
	{
		base.OnSelectEntered(args);
		currentAngle = FindWheelAngle();
		angularVelocity = 0.0f;
		isRotating = true;
	}

	protected override void OnSelectExited(SelectExitEventArgs args)
	{
		base.OnSelectExited(args);
		currentAngle = FindWheelAngle();
		isRotating = false;
	}

	public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
	{
		base.ProcessInteractable(updatePhase);

		if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
		{
			if (isRotating)
			{
				RotateWheel();
			}
			else
			{
				ApplyInertia();
			}
		}
	}

	private void RotateWheel()
	{
		float totalAngle = FindWheelAngle();
		float angleDifference = currentAngle - totalAngle;

		wheelTransform.Rotate(transform.forward, -angleDifference, Space.World);

		currentAngle = totalAngle;
		OnWheelRotated?.Invoke(angleDifference);
		angularVelocity = angleDifference / Time.deltaTime;

		// Calculate movement and rotation forces based on wheel rotation
		Vector3 movementForceVector = centerObject.transform.forward * movementForce * angularVelocity;
		Vector3 rotationForceVector = transform.up * rotationForce * angleDifference;

			// Apply forces to simulate friction and move rotation
			attachedRigidbody.AddForce(movementForceVector, ForceMode.Force);

			// Calculate torque based on the rotation force
			Vector3 torque = rotationForceVector;

			// Apply torque to simulate grip
			attachedRigidbody.AddTorque(torque, ForceMode.Force);

			// Calculate the desired rotation based on the wheel's rotation
			Quaternion desiredRotation = Quaternion.Euler(wheelTransform.eulerAngles);

			// Use MoveRotation to directly set the rotation
			attachedRigidbody.MoveRotation(desiredRotation);
	}


	private void ApplyInertia()
	{
		angularVelocity *= inertiaDampingFactor;
		wheelTransform.Rotate(transform.forward, -angularVelocity * Time.deltaTime, Space.World);
	}

	private float FindWheelAngle()
	{
		float totalAngle = 0;

		foreach (IXRSelectInteractor interactor in interactorsSelecting)
		{
			Vector2 direction = FindLocalPoint(interactor.transform.position);
			totalAngle += ConvertToAngle(direction) * FindRotationSensitivity();
		}

		return totalAngle;
	}

	private Vector2 FindLocalPoint(Vector3 position)
	{
		return transform.InverseTransformPoint(position).normalized;
	}

	private float ConvertToAngle(Vector2 direction)
	{
		return Vector2.SignedAngle(Vector2.up, direction);
	}

	private float FindRotationSensitivity()
	{
		return 1.0f / interactorsSelecting.Count;
	}
}
