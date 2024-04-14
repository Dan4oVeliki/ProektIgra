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

	// Update is called once per frame
	void Update()
    {
        
    }
    public void DoTheName()
    {
		foreach (var item in vsichkiVrati)
		{
			item.Moving = true;
		}
    }
}
