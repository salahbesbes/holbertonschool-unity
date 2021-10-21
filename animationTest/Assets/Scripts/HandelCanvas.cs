using UnityEngine;
using UnityEngine.UI;

public class HandelCanvas : MonoBehaviour
{
	//private void OnMouseEnter()
	//{
	//	Debug.Log($"mouse enter");
	//}

	private void OnMouseOver()
	{
		Image img = FindObjectOfType<Image>();
		img.color = Color.green;
	}

	private void OnMouseExit()
	{
		Image img = FindObjectOfType<Image>();
		img.color = Color.red;
	}
}