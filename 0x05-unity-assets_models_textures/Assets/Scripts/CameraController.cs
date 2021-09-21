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
		offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;

		Vector3 desiredPosition = player.position + offset;
		Vector3 SmoothPosition = Vector3.Lerp(transform.position, desiredPosition, 2f * Time.deltaTime);
		transform.position = SmoothPosition;
		transform.LookAt(player.position);
		// Rotate the player
		player.Rotate(Input.GetAxis("Mouse X") * turnSpeed * Vector3.up);
	}
}