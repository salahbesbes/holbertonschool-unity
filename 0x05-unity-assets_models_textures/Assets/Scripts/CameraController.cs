using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Vector3 offset;
	public Transform player;
	public float turnSpeed = 4.0f;
	private float rotation = 0f;
	public bool isInverted = false;

	private void Start()
	{
		offset = transform.position + player.position;
	}

	private void LateUpdate()
	{
		float mouseX = Input.GetAxis("Mouse X") * 300f * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;

		// by rotating the player: the cylinder and the head and the camera are rotating
		// simyltaly on the X axes

		// to rotate only the camera on the Y axes
		//rotation = isInverted ? rotation + mouseY : rotation - mouseY;

		//rotation = Mathf.Clamp(rotation, -90f, 90f);

		//transform.localRotation = Quaternion.Euler(mouseX, 0, 0);

		offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;

		Vector3 desiredPosition = player.position + offset;
		Vector3 SmoothPosition = Vector3.Lerp(transform.position, desiredPosition, 2f * Time.deltaTime);
		transform.position = SmoothPosition;
		transform.LookAt(player.position);
		// Rotate the player
		player.Rotate(Input.GetAxis("Mouse X") * turnSpeed * Vector3.up);

		//player.Rotate(Vector3.up * mouseX);
		//transform.Rotate(Vector3.up * mouseX);
		//player.Rotate(Vector3.down * mouseY);
		//transform.Rotate(Vector3.down * mouseY);
	}
}