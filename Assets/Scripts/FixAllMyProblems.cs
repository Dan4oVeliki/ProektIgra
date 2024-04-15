using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixAllMyProblems : MonoBehaviour
{
	public GameObject cam;
	void Update()
	{
		// Lock own rotation on X and Z axes
		transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

		// Inherit Y rotation from parent
		if (transform.parent != null)
		{
			Quaternion parentRotation = cam.transform.rotation;
			float parentYRotation = parentRotation.eulerAngles.y;
			transform.rotation = Quaternion.Euler(0f, parentYRotation, 0f);
		}
	}
}
