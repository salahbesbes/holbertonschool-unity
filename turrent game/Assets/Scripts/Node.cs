using UnityEngine;

public class Node : MonoBehaviour
{
	public Color hoverColor = Color.gray;
	private Color startColor;
	private Renderer rend;
	private GameObject turrentAlreadyExist = null;

	private void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	private void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}

	private void OnMouseDown()
	{
		if (turrentAlreadyExist)
		{
			Debug.Log("we cant build there !!");
			return;
		}
		// build turrent
	}
}