using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementController : MonoBehaviour
{
	private float moveSpeed = 15f;

	private Transform[] waypoints;
	private int currentWaypointIndex = 0;

	void Update()
	{
		if (waypoints == null || waypoints.Length == 0)
		{
			Debug.LogWarning("No waypoints assigned to car movement!");
			return;
		}

		MoveTowardsWaypoint();
	}

	void MoveTowardsWaypoint()
	{
		// Move towards the current waypoint
		transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

		// Check if the car has reached the current waypoint
		if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
		{
			if (currentWaypointIndex + 1 == waypoints.Length)
			{
				Destroy(gameObject);
			}
			currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
		}

		// Rotate towards the next waypoint
		RotateTowardsWaypoint();
	}

	void RotateTowardsWaypoint()
	{
		// Rotate towards the next waypoint
		Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
		if (direction != Vector3.zero)
		{
			Quaternion targetRotation = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
		}
	}

	public void SetWaypoints(Transform[] newWaypoints)
	{
		waypoints = newWaypoints;
		currentWaypointIndex = 0;
		MoveTowardsWaypoint();
	}
}
