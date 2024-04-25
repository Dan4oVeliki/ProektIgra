using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouSpinMeRightRound : MonoBehaviour
{
	public float rotationSpeed = 50f; // Speed at which the object will rotate

	void Update()
	{
		// Rotate the object around its Y-axis
		transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
	}
}
