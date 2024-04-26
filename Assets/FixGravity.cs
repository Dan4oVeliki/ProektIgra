using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixGravity : MonoBehaviour
{
	public GameObject targetObject; // The GameObject to toggle
	public bool isActive; // Initial state of the GameObject
	private void Update()
	{
		
		if (isActive)
		{
			targetObject.SetActive(true);
			
		}
		else
		{
			targetObject.SetActive(false);
		}
	}

	public void Activate()
	{
		isActive = !isActive;
	}
}
