using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnHit : MonoBehaviour
{
    [SerializeField] GameObject triggerObject;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == triggerObject)
		{
			ResetScene();
		}
	}
	private void ResetScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		SceneManager.LoadScene(currentSceneIndex);
	}
}
