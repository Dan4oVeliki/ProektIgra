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
		important = new Dictionary<string, int>();
		important.Add("studenchai", 0);
		important.Add("sokche", 0);
		important.Add("airqn", 0);
		important.Add("chips", 0);
		important.Add("bqlhab", 0);
		important.Add("pupesh", 0);
		important.Add("lukanka", 0);
		randoms = new List<string>();
	}
	public void Victory()
	{
		Dictionary<string, int> spisuk = new Dictionary<string, int>();
		spisuk.Add("studenchai", 4);
		spisuk.Add("sokche", 1);
		spisuk.Add("airqn", 3);
		spisuk.Add("chips", 2);
		spisuk.Add("bqlhab", 1);
		spisuk.Add("pupesh", 1);
		spisuk.Add("lukanka", 2);
		if (important==spisuk)
		{
			NextScene();
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (!inside && tags.Contains(other.tag))
		{
			important[other.tag]++;
		}
		else
		{
			randoms.Add(other.tag);
		}
			Victory();
		Destroy(other.gameObject);
	}
}
