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
	private bool isMoving;
	public XRPushButton buttonPress;

	public List<DoorController> Doors;
	public bool DoorsOpenButton;
	public bool isOpen;
	public bool ReachedFLoor;

	void Start()
	{
		TargetNextWaypoint();
	}

	void FixedUpdate()
	{
		Debug.Log($"{isOpen} {transform.position} MOVING {isMoving}");
		_elapsedTime += Time.deltaTime;
		foreach (var item in Doors)
		{
			if (item.closed)
			{
				isOpen = false;
			}
			else isOpen = true;
		}
		float elapsedPercentage = _elapsedTime / _timeToWaypoint;
		if (!isOpen)
		{
			elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
			transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
			transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);
		}
		buttonPress.Initialize();

		if (transform.position == new Vector3(-28.19328f, 9.3f, -4.95f) || transform.position == new Vector3(-28.19328f, -0.32f, -4.95f))
		{
			isMoving = false;

		}
		else {isMoving = true; ReachedFLoor = false; }
		if (elapsedPercentage >= 1 && buttonActivate && !isMoving)
		{
			TargetNextWaypoint();
		}
		else if (DoorsOpenButton && !isMoving)
		{
			foreach (var item in Doors)
			{
				item.Moving = true;
				DoorsOpenButton = false;
			}
			isOpen = true;
		}
		if (transform.position == new Vector3(-28.19328f, 9.3f, -4.95f) || transform.position == new Vector3(-28.19328f, -0.32f, -4.95f))
		{
			buttonActivate = false;
			if (!ReachedFLoor)
			{
				DoorsOpenButton= true;
			}
			ReachedFLoor = true;
		}
	}
	public void ButtonDoors()
	{
		DoorsOpenButton = true;
	}
	private void TargetNextWaypoint()
	{
		_previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
		_targetWaypointIndex = _waypointPath.GetNextPointIndex(_targetWaypointIndex);
		_targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

		_elapsedTime = 0;

		float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
		_timeToWaypoint = distanceToWaypoint / _speed;
	}
	public void GoToParter()
	{
		if (!isMoving)
		{
			_previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
			_targetWaypointIndex = 0;
			_targetWaypoint = _waypointPath.GetWaypoint(0);

			_elapsedTime = 0;

			float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
			_timeToWaypoint = distanceToWaypoint / _speed;
		}
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