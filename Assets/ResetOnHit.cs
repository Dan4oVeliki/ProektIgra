using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnHit : MonoBehaviour
{
    [SerializeField] GameObject triggerObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		// Check if the collider has collided with the specific game object
		if (other.gameObject == triggerObject)
		{
			// Reset the scene
			ResetScene();
		}
	}
	private void ResetScene()
	{
		// Get the current scene index
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		// Reload the current scene
		SceneManager.LoadScene(currentSceneIndex);
	}
}
