using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelController : MonoBehaviour
{
	public WheelCollider wheelCollider;
	public float SpeedWheel;
	private float tempvalue;
	public float BreakForce;

	public XRKnob interactable; // Reference to your XR Interactable (XR Knob, Button, etc.)
	public float resetDuration = 1f;

	private float currentValue;
	private float timeSinceLastInteraction;
	private void Start()
	{
		currentValue = interactable.GetComponent<XRKnob>().value; // Assuming XRKnob is used	
	}

	private void Update()
	{

		// Check if the XR Interactable is currently interacted with
		if (interactable.isSelected)
		{
			// Update the time since the last interaction
			timeSinceLastInteraction = 0f;
			if (interactable.value > 0.5f)
			{
				ApplyWheelTorque(SpeedWheel);
			}
			else if (interactable.value < 0.5f)
			{
				ApplyWheelTorque(-SpeedWheel);
			}
		}
		else
		{
			timeSinceLastInteraction += Time.deltaTime;

			// Check if it's time to reset the value
			if (timeSinceLastInteraction >= resetDuration)
			{
				interactable.value = 0.5f;
			}
			//if (interactable.value==0.5f)
			//{
			//	wheelCollider.brakeTorque = BreakForce;
			//}
		}
		Debug.Log($"{interactable.isSelected} {gameObject.name}");
	}

	private void ApplyWheelTorque(float torque)
	{
				Debug.Log("minava tova");

		wheelCollider.motorTorque = torque;
	}
}
