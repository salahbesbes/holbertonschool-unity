using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Vector3 offset;
	public Transform player;
	private float horizontalSpeed = 2.0f;
	private float verticalSpeed = 2.0f;
	public float turnSpeed = 4.0f;

	private void Start()
	{
		offset = transform.position;
	}

	private void LateUpdate()
	{
		offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		transform.position = player.position + offset;
		transform.LookAt(player.position);
	}
}