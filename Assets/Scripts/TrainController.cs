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
	public GameObject triggerObject;
    public bool PushedButton = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PushedButton&&cam.transform.rotation.eulerAngles.y > 150 && cam.transform.rotation.eulerAngles.y < 210)
        {
            StartTrain = true;
        }
        if (StartTrain&&!PushedButton)
        {
          rb.AddForce(0f, 0f, speedTrain, ForceMode.Acceleration);
        }
    }

    public void ForeverStop()
    {
        PushedButton = true;
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Kolichka")
        {
            other.transform.SetParent(transform);
        }
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Kolichka")
		{
			other.transform.SetParent(null);
		}
	}
}