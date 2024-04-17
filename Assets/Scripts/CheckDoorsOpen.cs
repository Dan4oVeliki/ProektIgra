using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDoorsOpen : MonoBehaviour
{
    public DoorController LDoor;
    public DoorController RDoor;
	[SerializeField]
	private bool AdminOn;
	private void Update()
	{
		if (AdminOn)
		{
			OpenDoors();
			AdminOn= false;
		}
	}
	public void OpenDoors()
    {
        LDoor.Moving = true;
        RDoor.Moving = true;
    }
}
