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

	}

	private void LateUpdate()
	{
		// update the value of isInverted from the game manager
		isInverted = GameManager.Instance.IsInverted;

		float mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;

		// by rotating the player: the cylinder and the head and the camera
		// are rotating simyltaly on the X axes
		player.Rotate(Vector3.up * mouseX);

		// to rotate only the camera on the Y axes
		rotation = isInverted ? rotation + mouseY : rotation - mouseY;


		rotation = Mathf.Clamp(rotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(rotation, 0, 0);

		//offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		//transform.position = player.position + offset;
		//transform.LookAt(player.position);
	}
}