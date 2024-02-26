using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    [SerializeField] string SceneName;
    public GameObject stol;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == stol)
		{
			NextScene();
		}
	}

	private void NextScene()
	{
		SceneManager.LoadScene(SceneName);
	}
}
