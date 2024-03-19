using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class WayPointEnumarator : MonoBehaviour
{
	public Transform GetWaypoint(int waypointIndex) 
	{
		return transform.GetChild(waypointIndex);
	}
	public int GetNextPointIndex(int waypointIndex)
	{
		waypointIndex++;
		if (waypointIndex>=transform.childCount)
		{
			waypointIndex = 0;
		}
		return waypointIndex;
	}

}
