using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ElevatorController : MonoBehaviour
{
	[SerializeField]
	private WayPointEnumarator _waypointPath;

	[SerializeField]
	private float _speed;

	private int _targetWaypointIndex;

	private Transform _previousWaypoint;
	private Transform _targetWaypoint;

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
		transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
		transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);
		buttonPress.Initialize();

		if (elapsedPercentage >= 1&& buttonActivate)
		{
			TargetNextWaypoint();
		}
	}

	private void TargetNextWaypoint()
	{
		_previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
		_targetWaypointIndex = _waypointPath.GetNextPointIndex(_targetWaypointIndex);
		_targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

		_elapsedTime = 0;

		float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
		_timeToWaypoint = distanceToWaypoint / _speed;

		buttonActivate= false;
	}
	public void ClickButton()
	{
		buttonActivate = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Kolichka")
		{
			other.transform.SetParent(transform);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Kolichka")
		{
			other.transform.SetParent(null);
		}
	}
}
