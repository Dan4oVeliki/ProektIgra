using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ColliderVisualizer : MonoBehaviour
{
	public Color highlightColor = Color.yellow;
	public bool visualizeOnStart = true;

	private Collider _collider;
	private Material _highlightMaterial;

	private void Start()
	{
		_collider = GetComponent<Collider>();

		// Create a new material for highlighting
		_highlightMaterial = new Material(Shader.Find("Standard"));
		_highlightMaterial.color = highlightColor;

		if (visualizeOnStart)
			VisualizeCollider();
	}

	public void VisualizeCollider()
	{
		// Create a GameObject to represent the collider
		GameObject colliderVisual = GameObject.CreatePrimitive(PrimitiveType.Cube);
		colliderVisual.transform.position = _collider.bounds.center;
		colliderVisual.transform.localScale = _collider.bounds.size;
		colliderVisual.GetComponent<Renderer>().material = _highlightMaterial;

		// Ensure the collider visual does not interact with other colliders
		Destroy(colliderVisual.GetComponent<Collider>());
	}
}
