using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
	public float greenTime = 5f;
	public float yellowTime = 2f;
	public float redTime = 5f;
	public float initialDelay = 0f; 

	private Light[] lights;
	private int currentLightIndex = 0;
	private float timer = 0f;
	private bool isInitialDelayComplete = false;

	public bool isRed;
	void Start()
	{
		lights = GetComponentsInChildren<Light>();

		StartCoroutine(InitialDelayCoroutine());
	}

	IEnumerator InitialDelayCoroutine()
	{
		yield return new WaitForSeconds(initialDelay);
		isInitialDelayComplete = true; 
		SwitchToGreenLight(); 
	}

	void Update()
	{
		if (!isInitialDelayComplete) 
			return;

		timer += Time.deltaTime;
		isRed = lights[2].enabled;
		if (timer >= GetCurrentLightDuration())
		{
			SwitchToNextLight();
			timer = 0f;
		}
	}

	float GetCurrentLightDuration()
	{
		switch (currentLightIndex)
		{
			case 0:
				return greenTime;
			case 1:
				return yellowTime;
			case 2:
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
			case 0: 
				SwitchToYellowLight();
				break;
			case 1: 
				SwitchToRedLight();
				break;
			case 2: 
				SwitchToGreenLight();
				break;
			default:
				break;
		}
	}
}
