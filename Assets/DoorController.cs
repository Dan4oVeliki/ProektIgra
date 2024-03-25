using UnityEngine;

public class DoorController : MonoBehaviour
{
	public Transform leftDoor;
	public Transform rightDoor;

	public float slideDistance = 2f;
	public float slideSpeed = 5f;

	private Vector3 leftDoorClosedPosition;
	private Vector3 rightDoorClosedPosition;

	private Vector3 leftDoorOpenPosition;
	private Vector3 rightDoorOpenPosition;
	[SerializeField]
	private bool isOpen = false;

	void Start()
	{
		// Store initial positions
		leftDoorClosedPosition = leftDoor.localPosition;
		rightDoorClosedPosition = rightDoor.localPosition;

		// Calculate open positions
		leftDoorOpenPosition = leftDoorClosedPosition + Vector3.left * slideDistance;
		rightDoorOpenPosition = rightDoorClosedPosition + Vector3.right * slideDistance;
	}

	void Update()
	{
		// If isOpen is true, open the doors
		if (isOpen)
		{
			OpenDoors();
		}
		else
		{
			CloseDoors();
		}
	}

	void OpenDoors()
	{
		leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftDoorOpenPosition, Time.deltaTime * slideSpeed);
		rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightDoorOpenPosition, Time.deltaTime * slideSpeed);
	}

	void CloseDoors()
	{
		leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftDoorClosedPosition, Time.deltaTime * slideSpeed);
		rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightDoorClosedPosition, Time.deltaTime * slideSpeed);
	}
	public void ToggleDoors()
	{
		isOpen = !isOpen;
	}
}