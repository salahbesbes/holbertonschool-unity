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
		// if the game is over stop moving the camera
		if (GameManager.GameIsOver == true)
		{
			this.enabled = false;
		}

		if (Input.GetKey("z"))
		{
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s"))
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d"))
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("q"))
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;
		pos.y -= scroll * scrollSpeed * Time.deltaTime * 500;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);
		transform.position = pos;
	}
}