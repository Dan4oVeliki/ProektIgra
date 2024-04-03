using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
	public GameObject[] side1Lights; // Lights on side 1
	public GameObject[] side2Lights; // Lights on side 2

	public float greenDuration = 5f; // Duration for green light
	public float yellowDuration = 2f; // Duration for yellow light
	public float redDuration = 5f; // Duration for red light

	private bool isSide1Green = true; // Flag to track which side is green

	private void Start()
	{
		// Start the traffic light cycle
		StartCoroutine(TrafficLightCycle());
	}

	private IEnumerator TrafficLightCycle()
	{
		while (true)
		{
			if (isSide1Green)
			{
				SetSide1Lights(true, false, false); // Set side 1 to green
				yield return new WaitForSeconds(greenDuration);

				SetSide1Lights(false, true, false); // Set side 1 to yellow
				yield return new WaitForSeconds(yellowDuration);

				SetSide1Lights(false, false, true); // Set side 1 to red
				yield return new WaitForSeconds(redDuration);
			}
			else
			{
				SetSide2Lights(true, false, false); // Set side 2 to green
				yield return new WaitForSeconds(greenDuration);

				SetSide2Lights(false, true, false); // Set side 2 to yellow
				yield return new WaitForSeconds(yellowDuration);

				SetSide2Lights(false, false, true); // Set side 2 to red
				yield return new WaitForSeconds(redDuration);
			}

			// Toggle the flag to switch sides
			isSide1Green = !isSide1Green;
		}
	}

	public void SetSide1Lights(bool red, bool yellow, bool green)
	{
		SetLights(side1Lights, red, yellow, green);
	}

	public void SetSide2Lights(bool red, bool yellow, bool green)
	{
		SetLights(side2Lights, red, yellow, green);
	}

	private void SetLights(GameObject[] lights, bool red, bool yellow, bool green)
	{
		foreach (GameObject light in lights)
		{
			if (light != null)
			{
				Light lightComponent = light.GetComponent<Light>();

				if (light.name.Contains("Red"))
					lightComponent.enabled = red;
				else if (light.name.Contains("Yellow"))
					lightComponent.enabled = yellow;
				else if (light.name.Contains("Green"))
					lightComponent.enabled = green;
			}
		}
	}
}