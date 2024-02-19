using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class NewestWheel : XRBaseInteractable
{
    [SerializeField] private Transform wheelTransform;
	[SerializeField] private Rigidbody attachedRigidbody;
	[SerializeField] float ForcePush;
	public Transform PushFromHere;
	public UnityEvent<float> OnWheelRotated;

	private float currentAngle = 0.0f;
	private float angularVelocity = 0.0f;
	private bool isSlowingDown = false;
	private float dampingFactor = 0.95f;

	protected override void OnSelectEntered(SelectEnterEventArgs args)
	{
		base.OnSelectEntered(args);
		currentAngle = FindWheelAngle();
		angularVelocity = 0.0f;
		isSlowingDown = false;
	}

	protected override void OnSelectExited(SelectExitEventArgs args)
	{
		base.OnSelectExited(args);
		currentAngle = FindWheelAngle();
		isSlowingDown = true;
	}

	public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
	{
		base.ProcessInteractable(updatePhase);

		if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
		{
			if (isSelected)
				RotateWheel();
			else
				ApplyAngularVelocity();
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

		if (isSlowingDown)
		{
			angularVelocity *= dampingFactor;
		}

		// Calculate force direction based on PushFromHere position
		Vector3 forceDirection = PushFromHere.position - wheelTransform.position;
		forceDirection.Normalize();

		// Apply a force to the attached Rigidbody to move the object forward
		Vector3 forwardForce = forceDirection * angularVelocity * Time.deltaTime * ForcePush;
		attachedRigidbody.AddForce(0f,0f,1f,ForceMode.Acceleration);

		// Apply a torque to simulate the turning effect (optional)
		float torque = angularVelocity * 0.1f;
		attachedRigidbody.AddTorque(transform.up * torque);
	}


	private void ApplyAngularVelocity()
	{
		wheelTransform.Rotate(transform.forward, -angularVelocity * Time.deltaTime, Space.World);
		angularVelocity *= 0.98f;
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
