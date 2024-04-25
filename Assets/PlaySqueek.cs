using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySqueek : MonoBehaviour
{
	private Quaternion parentRotation;
	private AudioSource zvuk;
	void Start()
    {
		zvuk = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
    {
		 parentRotation = transform.parent.rotation;
		if (parentRotation.x %180==0)
		{
			zvuk.Play();
		}
    }
}
