using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuCOntroller : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty showButton;
    public Transform head;
    public float MenuDistance;
    private bool IsGamePaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		if (showButton.action.WasPressedThisFrame())
		{
			OpenMenu();
		}
		if (IsGamePaused)
		{
			Time.timeScale = 0f;
		}
		else Time.timeScale = 1f;
		menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
		menu.transform.forward *= -1f;
	}

	public void OpenMenu()
	{
		
			menu.SetActive(!menu.activeSelf);

			menu.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * MenuDistance;

			IsGamePaused = !IsGamePaused;
	}
}
