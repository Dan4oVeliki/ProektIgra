using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
	public AudioSource elevatorAudio;
	private bool playerInside = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			playerInside = true;
			elevatorAudio.Play();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			playerInside = false;
			elevatorAudio.Stop();
		}
	}

	private void Start()
	{
		// Set the audio clip to loop
		elevatorAudio.loop = true;
	}
}
