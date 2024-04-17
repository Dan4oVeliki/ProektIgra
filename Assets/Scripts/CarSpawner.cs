using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
	public GameObject[] carPrefabs;
	public Transform[] spawnPoints;
	public Transform[] waypoints;
	public float spawnInterval = 2f;

	private float timer = 0f;

	public TrafficLightController TrafficLight;
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= spawnInterval)
		{
			SpawnCar();
			timer = 0f;
		}
	}

	void SpawnCar()
	{
		GameObject selectedCarPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];
		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		GameObject newCar = Instantiate(selectedCarPrefab, spawnPoint.position, spawnPoint.rotation);

		CarMovementController carMovement = newCar.GetComponent<CarMovementController>();
		if (carMovement != null)
		{
			carMovement.SetWaypoints(waypoints);
			carMovement.AttachTrafficLightController(TrafficLight); // Attach TrafficLightController
		}
	}
}
