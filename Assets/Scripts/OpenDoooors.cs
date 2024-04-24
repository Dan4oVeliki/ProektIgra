using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoooors : MonoBehaviour
{
	public GameObject vrati;
	private List<AutomaticDoorSuperMarket> vsichkiVrati;
	public bool start;

	void Start()
	{
		vsichkiVrati = new List<AutomaticDoorSuperMarket>();
		vsichkiVrati.AddRange(vrati.GetComponentsInChildren<AutomaticDoorSuperMarket>());
		if (start)
		{
			DoTheName();
		}
	}
    public void DoTheName()
    {
		foreach (var item in vsichkiVrati)
		{
			item.Moving = true;
		}
    }
}
