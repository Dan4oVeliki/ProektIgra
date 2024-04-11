using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerKinda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerStay(Collider other)
	{
        if (other.tag=="SDoor")
        {
            if (other.GetComponent<AutomaticDoorSuperMarket>().Moving == false)
            {
                other.GetComponent<AutomaticDoorSuperMarket>().Moving = true;

			}
        }
	}
}
