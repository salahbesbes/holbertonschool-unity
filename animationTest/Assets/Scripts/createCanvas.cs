using UnityEngine;
using UnityEngine.UI;

public class createCanvas : MonoBehaviour
{
	private MeshRenderer renderer;
	private Vector3 size;
	private Transform CanvasContainer;

	private void Start()
	{
		renderer = GetComponent<MeshRenderer>();
		size = renderer.bounds.size;
		Debug.Log($"{size}");
		CreateMainCanvas();
		RightSideCanvas();
		LeftSideCanvas();
		FrontSideCanvas();
		BackSideCanvas();
	}

	private void Update()
	{
	}

	private void CreateMainCanvas()
	{
		GameObject newCanvas = new GameObject("CanvasContainer");
		newCanvas.transform.SetParent(transform, false);
		CanvasContainer = newCanvas.transform;
		//CanvasContainer.position = transform.position + new Vector3(size.x / 2, size.y / 2, -size.z / 2);
		CanvasContainer.position = transform.position;
	}

	private void FrontSideCanvas()
	{
		GameObject newCanvas = new GameObject("Canvas");
		newCanvas.transform.SetParent(CanvasContainer, false);
		newCanvas.transform.position = transform.position + Vector3.up;
		//newCanvas.transform.localRotation = Quaternion.Euler(0, 0, 0);
		Canvas c = newCanvas.AddComponent<Canvas>();
		c.renderMode = RenderMode.WorldSpace;
		newCanvas.AddComponent<HorizontalLayoutGroup>();
		newCanvas.AddComponent<CanvasScaler>();
		newCanvas.AddComponent<GraphicRaycaster>();

		RectTransform rt = newCanvas.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(Mathf.Round(size.x), 1.6f);
		//newCanvas.transform.position += Vector3.forward * (Mathf.Round(size.z) / 2 + Mathf.Round(size.z) * 0.2f / 2);
		newCanvas.transform.position = CanvasContainer.position + Vector3.forward * (Mathf.Round(size.z) / 2 + 0.02f);

		for (int i = 0; i < Mathf.Round(size.x); i++)
		{
			GameObject panel = new GameObject("Panel");
			panel.AddComponent<CanvasRenderer>();
			Image image = panel.AddComponent<Image>();
			image.color = i % 2 == 0 ? Color.red : Color.green;
			panel.transform.SetParent(newCanvas.transform, false);
		}
		//newCanvas.transform.localScale += Vector3.right * 0.2f;
	}

	private void BackSideCanvas()
	{
		GameObject newCanvas = new GameObject("Canvas");
		newCanvas.transform.SetParent(CanvasContainer, false);
		newCanvas.transform.position = transform.position + Vector3.up;
		//newCanvas.transform.localRotation = Quaternion.Euler(0, 0, 0);
		Canvas c = newCanvas.AddComponent<Canvas>();
		c.renderMode = RenderMode.WorldSpace;
		newCanvas.AddComponent<HorizontalLayoutGroup>();
		newCanvas.AddComponent<CanvasScaler>();
		newCanvas.AddComponent<GraphicRaycaster>();

		RectTransform rt = newCanvas.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(Mathf.Round(size.x), 1.6f);
		newCanvas.transform.position = CanvasContainer.position + Vector3.back * (Mathf.Round(size.z) / 2 + 0.02f);

		for (int i = 0; i < Mathf.Round(size.x); i++)
		{
			GameObject panel = new GameObject("Panel");
			panel.AddComponent<CanvasRenderer>();
			Image image = panel.AddComponent<Image>();
			image.color = i % 2 == 0 ? Color.red : Color.green;
			panel.transform.SetParent(newCanvas.transform, false);
		}
	}

	private void RightSideCanvas()
	{
		GameObject newCanvas = new GameObject("Canvas");
		newCanvas.transform.SetParent(CanvasContainer, false);
		newCanvas.transform.position = transform.position + Vector3.up;
		newCanvas.transform.localRotation = Quaternion.Euler(0, 90, 0);
		Canvas c = newCanvas.AddComponent<Canvas>();
		c.renderMode = RenderMode.WorldSpace;
		newCanvas.AddComponent<HorizontalLayoutGroup>();
		newCanvas.AddComponent<CanvasScaler>();
		newCanvas.AddComponent<GraphicRaycaster>();

		RectTransform rt = newCanvas.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(Mathf.Round(size.z), 1.6f);
		newCanvas.transform.position = CanvasContainer.position + Vector3.right * (Mathf.Round(size.x) / 2 + 0.02f);

		for (int i = 0; i < Mathf.Round(size.z); i++)
		{
			GameObject panel = new GameObject("Panel");
			panel.AddComponent<CanvasRenderer>();
			Image image = panel.AddComponent<Image>();
			image.color = i % 2 == 0 ? Color.red : Color.green;
			panel.transform.SetParent(newCanvas.transform, false);
		}
	}

	private void LeftSideCanvas()
	{
		GameObject newCanvas = new GameObject("Canvas");
		newCanvas.transform.SetParent(CanvasContainer, false);
		newCanvas.transform.position = transform.position + Vector3.up;
		newCanvas.transform.localRotation = Quaternion.Euler(0, 90, 0);
		Canvas c = newCanvas.AddComponent<Canvas>();
		c.renderMode = RenderMode.WorldSpace;
		newCanvas.AddComponent<HorizontalLayoutGroup>();
		newCanvas.AddComponent<CanvasScaler>();
		newCanvas.AddComponent<GraphicRaycaster>();

		RectTransform rt = newCanvas.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(Mathf.Round(size.z), 1.6f);
		newCanvas.transform.position = CanvasContainer.position + Vector3.left * (Mathf.Round(size.x) / 2 + 0.02f);
		for (int i = 0; i < Mathf.Round(size.z); i++)
		{
			GameObject panel = new GameObject("Panel");
			panel.AddComponent<CanvasRenderer>();
			Image image = panel.AddComponent<Image>();
			image.color = i % 2 == 0 ? Color.red : Color.green;
			panel.transform.SetParent(newCanvas.transform, false);
		}
	}
}