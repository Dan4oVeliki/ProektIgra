using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{

	public Color outlineColor = Color.black;
	public float outlineWidth = 0.05f;

	private Material outlineMaterial;
	private Renderer objectRenderer;

	void Start()
	{
		objectRenderer = GetComponent<Renderer>();
		outlineMaterial = new Material(Shader.Find("Assets/Shaders/OutlineShader.shader"));
		outlineMaterial.SetColor("_OutlineColor", outlineColor);
		outlineMaterial.SetFloat("_OutlineWidth", outlineWidth);

		objectRenderer.material = outlineMaterial;
	}
}
