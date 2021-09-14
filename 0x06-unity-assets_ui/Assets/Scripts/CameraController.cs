using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Vector3 offset;
	public Transform player;
	public float turnSpeed = 4.0f;

	private void Start()
	{
		offset = transform.position - player.position;
	}

	private void LateUpdate()
	{
		offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		transform.position = player.position + offset;
		transform.LookAt(player.position);
	}
}