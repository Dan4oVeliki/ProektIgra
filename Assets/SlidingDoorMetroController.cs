using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SlidingDoorMetroController : MonoBehaviour
{
	[SerializeField]
	private float _speed;

	[SerializeField]
	private float _howFar;

	private Transform _previousWaypoint;
	private Vector3 _targetWaypoint;

	private float _timeToWaypoint;
	private float _elapsedTime;

	public bool buttonActivate;

	public XRPushButton buttonPress;

	void Start()
	{
		TargetNextWaypoint();
	}

	void FixedUpdate()
	{
		_elapsedTime += Time.deltaTime;

		float elapsedPercentage = _elapsedTime / _timeToWaypoint;
		elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
		transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint, elapsedPercentage);
		buttonPress.Initialize();

		if (elapsedPercentage >= 1 && buttonActivate)
		{
			TargetNextWaypoint();
		}
	}

	private void TargetNextWaypoint()
	{
		_previousWaypoint = transform;
		_targetWaypoint = transform.position + new Vector3(0, 0, 5);

		_elapsedTime = 0;

		float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint);
		_timeToWaypoint = distanceToWaypoint / _speed;

		buttonActivate = false;
	}

	public void ClickButton()
	{
		buttonActivate = true;
	}
}
