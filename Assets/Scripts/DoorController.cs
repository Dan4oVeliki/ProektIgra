using UnityEngine;

public class DoorController : MonoBehaviour
{
	public Vector3 endPos;
	public float speed;

	private bool opening;
	private bool moving;
	private Vector3 startPos;
	private float delay;

	public bool closed;
	void Start()
	{
		startPos = transform.localPosition;
	}

	void Update()
	{
		// If isOpen is true, open the doors
		if (moving)
		{
			if (opening)
			{
				OpenDoors(endPos);
			}
			else
			{
				OpenDoors(startPos);
			}
		}
		Debug.Log($"door cod{closed}");
	}

	void OpenDoors(Vector3 goalPos)
	{
		float dist = Vector3.Distance(transform.localPosition, goalPos);
		if (dist > .1f) 
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, goalPos, speed*Time.deltaTime);
		}
		else
		{
			if (opening)
			{
				delay += Time.deltaTime;
				if (delay-speed>9f)
				{
					opening = false;
				}
				closed = false;
			}
			else 
			{ 
				moving= false;
				opening= true;
				if (goalPos == startPos)
				{
					closed = true;
				}
			}
		}

	}
	public bool Moving
	{
		get { return moving; }
		set { moving = value; }
	}
}