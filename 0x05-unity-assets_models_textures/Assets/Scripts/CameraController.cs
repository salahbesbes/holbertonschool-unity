using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform player;
	Vector3 offset;
	float horizontalSpeed = 2.0f;
	float verticalSpeed = 2.0f;
	public float turnSpeed = 4.0f;


	void Start()
	{
		offset = transform.position;
	}

	void LateUpdate()
	{
		offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		transform.position = player.position + offset;
		transform.LookAt(player.position);
	}
}
