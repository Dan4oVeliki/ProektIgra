using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainController : MonoBehaviour
{
    public Rigidbody rb;
    public float speedTrain;
    public Camera cam;
    public bool StartTrain;
    public BoxCollider col;
	public GameObject triggerObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.rotation.eulerAngles.y > 150 && cam.transform.rotation.eulerAngles.y < 210)
        {
            StartTrain = true;
        }
        if (StartTrain)
        {
          rb.AddForce(0f, 0f, speedTrain, ForceMode.Acceleration);

        }
        Debug.Log(cam.transform.rotation.eulerAngles.y);
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
