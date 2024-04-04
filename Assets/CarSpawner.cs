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
		// Select a random car prefab
		GameObject selectedCarPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];

		// Select a random spawn point
		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

		// Instantiate the car at the spawn point
		GameObject newCar = Instantiate(selectedCarPrefab, spawnPoint.position, spawnPoint.rotation);

		// Get the CarMovement component and set the waypoints
		CarMovementController carMovement = newCar.GetComponent<CarMovementController>();
		if (carMovement != null)
		{
			carMovement.SetWaypoints(waypoints);
		}
	}
}
