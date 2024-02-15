using UnityEngine.XR.Content.Interaction;
using UnityEngine;

public class WheelController : MonoBehaviour
{
	public WheelCollider wheelCollider;
	public float SpeedWheel;
	public float BreakForce;
	public XRKnob interactable;
	public float resetDuration = 1f;

	private float currentValue;
	private float timeSinceLastInteraction;

	private void Start()
	{
		currentValue = interactable.value;
	}

	private void Update()
	{
		if (interactable.isSelected)
		{
			timeSinceLastInteraction = 0f;
			if (interactable.value > 0.5f)
			{
				ApplyWheelTorque(SpeedWheel*(interactable.value*2));
			}
			else if (interactable.value < 0.5f)
			{
				ApplyWheelTorque(-SpeedWheel * (interactable.value * 2));
			}
		}
		else
		{
			timeSinceLastInteraction += Time.deltaTime;

			if (timeSinceLastInteraction >= resetDuration)
			{
				interactable.value = 0.5f;
			}

			if (interactable.value == 0.5f && wheelCollider.rpm > 0.1f && timeSinceLastInteraction >= resetDuration)
			{
				// Check if brake torque is not already applied
				if (wheelCollider.brakeTorque == 0f)
				{
					Debug.Log("SPIRACHKAAAA" + gameObject.name);
					wheelCollider.brakeTorque = BreakForce;
				}
			}
			else
			{
				// Reset brake torque when conditions are not met
				wheelCollider.brakeTorque = 0f;
			}
		}
		Debug.Log($"{interactable.isSelected} {gameObject.name}");
		Debug.Log($"{wheelCollider.rpm} SKOROST {gameObject.name}");
	}

	private void ApplyWheelTorque(float torque)
	{
		Debug.Log($"Applying Torque {torque}");
		if (torque>300)
		{
			wheelCollider.motorTorque = 300;
			return;
		}
		wheelCollider.motorTorque = torque;
	}
}

