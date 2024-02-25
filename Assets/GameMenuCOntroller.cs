using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.NativeTypes;

public class GameMenuCOntroller : MonoBehaviour
{
	public GameObject menu;
	public InputActionProperty showButton;
	public Transform head;
	public float MenuDistance;
	private bool IsGamePaused = false;
	public GameObject LHand;
	public GameObject RHand;
	private LineRenderer lineRendererLHand; 
	private LineRenderer lineRendererRHand; 
	private XRInteractorLineVisual LHandRay;
	private XRInteractorLineVisual RHandRay;
	void Start()
	{ 
		lineRendererLHand = LHand.GetComponent<LineRenderer>();
		lineRendererRHand = RHand.GetComponent<LineRenderer>();
		LHandRay = LHand.GetComponent<XRInteractorLineVisual>();
		RHandRay = RHand.GetComponent<XRInteractorLineVisual>();
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

		if (!menu.activeSelf)
		{
			// Disable the line renderers when the menu is active
			LHandRay.enabled = false;
			RHandRay.enabled = false;
			lineRendererLHand.enabled = false;
			lineRendererRHand.enabled = false;
		}
		else
		{
			// Enable the line renderers when the menu is not active
			LHandRay.enabled = true;
			RHandRay.enabled = true;
			lineRendererLHand.enabled = true;
			lineRendererRHand.enabled = true;
		}

		menu.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * MenuDistance;

		IsGamePaused = !IsGamePaused;
	}
}
