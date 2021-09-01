using UnityEngine;

public class Node : MonoBehaviour
{
	public Color hoverColor = Color.gray;
	private Color startColor;
	private Renderer rend;
	private GameObject turrentExist = null;
	private Vector3 offset = new Vector3(0, 0.5f, 0);

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
		if (turrentExist)
		{
			Debug.Log("we cant build there !!");
			return;
		}
		// build turrent
		GameObject turrentToBuild = BuildManager.instance.TurrentToBuild;
		turrentExist = Instantiate(turrentToBuild, transform.position, transform.rotation).gameObject;
	}
}