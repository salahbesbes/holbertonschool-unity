using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Vector3 offset;
	public Transform player;
	public float turnSpeed = 4.0f;
	private float rotation, rotationY = 0f;
	public bool isInverted = false;

	private void Start()
	{
		offset = transform.position - player.position;
	}

	private void LateUpdate()
	{
		// update the value of isInverted from the game manager
		//isInverted = GameManager.Instance.IsInverted;

		// if we update turnSpeed to 400f and replace 100f * 4f it wont work
		float mouseX = Input.GetAxis("Mouse X") * 70f * turnSpeed * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * 70f * turnSpeed * Time.deltaTime;

		//player.Rotate(Vector3.up * mouseX);

		// to rotate only the camera on the Y axes
		//rotation = isInverted ? rotation + mouseY : rotation - mouseY;
		//rotationY += mouseX;
		transform.position = player.position + offset;
		rotation = Mathf.Clamp(rotation, -90f, 90f);
		rotationY = Mathf.Clamp(rotationY, -90f, 90f);

		transform.localRotation = Quaternion.Euler(rotation, rotationY, 0);
	}
}