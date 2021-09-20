using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	public Color hoverColor = Color.gray;
	private Color startColor;
	private Renderer rend;
	public Vector3 offset = new Vector3(0, 0.5f, 0);
	BuildManager buildManager;
	public Color notEnoughMoneyColor;

	[Header("Optional")]
	public GameObject turrent = null;
	private void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		buildManager = BuildManager.instance;
	}

	private void OnMouseEnter()
	{
		// check if we are hovering into a UI element
		if (EventSystem.current.IsPointerOverGameObject()) return;
		// check if we are selectiong a turrent
		if (!buildManager.CanBuild) return;

		// hover animation activate only if we are selecting a turrent
		if (buildManager.HasMoney) rend.material.color = hoverColor;
		else rend.material.color = notEnoughMoneyColor;

	}

	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}
	private void OnMouseDown()
	{
		// check if we are hovering into a UI element
		if (EventSystem.current.IsPointerOverGameObject()) return;

		// if we click on node without selecting a turrent dont do any thing
		if (!buildManager.CanBuild) return;


		// if we select urrent and want to build on top some other turrent
		if (turrent)
		{
			Debug.Log("we cant build there !!");
			return;
		}

		//// build turrent
		buildManager.BuildTurrentOn(this);
	}
}