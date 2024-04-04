using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public float greenTime = 5f;
	public float yellowTime = 2f;
	public float redTime = 5f;

	private Light[] lights;
	private int currentLightIndex = 0;
	private float timer = 0f;

	void Start()
	{
		// Get all child lights
		lights = GetComponentsInChildren<Light>();

		// Start with green light
		SwitchToGreenLight();
	}

	void Update()
	{
		// Update the timer
		timer += Time.deltaTime;

		// Check if it's time to switch lights
		if (timer >= GetCurrentLightDuration())
		{
			SwitchToNextLight();
			timer = 0f; // Reset the timer
		}
	}

	float GetCurrentLightDuration()
	{
		switch (currentLightIndex)
		{
			case 0: // Green light
				return greenTime;
			case 1: // Yellow light
				return yellowTime;
			case 2: // Red light
				return redTime;
			default:
				return 0f;
		}
	}

	void SwitchToGreenLight()
	{
		currentLightIndex = 0;
		lights[0].enabled = true;
		lights[1].enabled = false;
		lights[2].enabled = false;
	}

	void SwitchToYellowLight()
	{
		currentLightIndex = 1;
		lights[0].enabled = false;
		lights[1].enabled = true;
		lights[2].enabled = false;
	}

	void SwitchToRedLight()
	{
		currentLightIndex = 2;
		lights[0].enabled = false;
		lights[1].enabled = false;
		lights[2].enabled = true;
	}

	void SwitchToNextLight()
	{
		switch (currentLightIndex)
		{
			case 0: // Green light, switch to yellow
				SwitchToYellowLight();
				break;
			case 1: // Yellow light, switch to red
				SwitchToRedLight();
				break;
			case 2: // Red light, switch to green
				SwitchToGreenLight();
				break;
			default:
				break;
		}
	}
}