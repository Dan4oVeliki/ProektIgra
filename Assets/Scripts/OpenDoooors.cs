using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoooors : MonoBehaviour
{
	public GameObject vrati;
	private List<AutomaticDoorSuperMarket> vsichkiVrati;

	void Start()
	{
		vsichkiVrati = new List<AutomaticDoorSuperMarket>();
		vsichkiVrati.AddRange(vrati.GetComponentsInChildren<AutomaticDoorSuperMarket>());
	}
    public void DoTheName()
    {
		foreach (var item in vsichkiVrati)
		{
			item.Moving = true;
		}
    }
}
