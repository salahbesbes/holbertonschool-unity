using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float panSpeed = 30f;
	public float scrollSpeed = 30f;
	private float borderThikness = 10f;
	private float minY = 10f;
	private float maxY = 80f;

	private void Update()
	{
		if (Input.GetKey("z") || Input.mousePosition.y >= Screen.height - borderThikness)
		{
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= borderThikness)
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderThikness)
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("q") || Input.mousePosition.x <= borderThikness)
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}



		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;
		pos.y -= scroll * scrollSpeed * Time.deltaTime * 1000;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);
		transform.position = pos;


	}
}
