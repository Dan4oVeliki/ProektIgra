using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoshnicaController : MonoBehaviour
{
	public List<GameObject> importantTags;
	private Dictionary<string, int> important;
	private List<string> tags;
	private bool inside;
	private List<string> randoms;
	[SerializeField] string SceneName;
	public GameObject stol;

	private int sum = 0;
	private void NextScene()
	{
		SceneManager.LoadScene(SceneName);
	}
	void Start()
	{
		tags = new List<string>();
		for (int i = 0; i < importantTags.Count; i++)
		{
			tags.Add(importantTags[i].tag);
		}
		randoms = new List<string>();
	}
	public void Victory()
	{
		if (sum>=14)
		{
			NextScene();
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (!inside && tags.Contains(other.tag))
		{
			sum++;
		}
		else
		{
			randoms.Add(other.tag);
		}
			Victory();
		Destroy(other.gameObject);
	}
}
