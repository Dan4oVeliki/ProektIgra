using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovementController : MonoBehaviour
{
	private float moveSpeed = 15f;
	private Transform[] waypoints;
	private int currentWaypointIndex = 0;
	private bool stopMovement = false;
	public TrafficLightController trafficLight;
	void Update()
	{
		if (waypoints == null || waypoints.Length == 0)
		{
			Debug.LogWarning("No waypoints assigned to car movement!");
			return;
		}
		stopMovement = trafficLight.isRed;
		if (!stopMovement || (waypoints[currentWaypointIndex].name.StartsWith("stop_")))
		{
			MoveTowardsWaypoint();
		}
	}

	void MoveTowardsWaypoint()
	{
		transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

		
		if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
		{
			if (currentWaypointIndex + 1 == waypoints.Length)
			{
				Destroy(gameObject);
			}
			currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
		}

		
		RotateTowardsWaypoint();
	}

	void RotateTowardsWaypoint()
	{
		
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

	public void SetStopMovement(bool stop)
	{
		if (trafficLight.isRed)
		{
			stopMovement = stop;
		}
	}
	public void AttachTrafficLightController(TrafficLightController trafficLights)
	{
		trafficLight = trafficLights;
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Kolichka")
		{
			UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}
	}
}
