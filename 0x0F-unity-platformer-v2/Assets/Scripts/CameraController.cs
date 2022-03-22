using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	private Vector3 offset;
	public Transform player;
	public float turnSpeed = 4.0f;
	private float rotation, rotationX = 0f;
	public bool isInverted = false;
	public InputAction input;

	private void Start()
	{
		input.Enable();
		offset = transform.position - player.position;
		Cursor.lockState = CursorLockMode.Confined;
	}

	private void OnDisable()
	{
		input.Disable();
	}

	private void LateUpdate()
	{
		// update the value of isInverted from the game manager
		isInverted = GameManager.Instance.IsInverted;

		// if we update turnSpeed to 400f and replace 100f * 4f it wont work

		Vector2 mouse = input.ReadValue<Vector2>();
		float mouseX = mouse.x * 20 * turnSpeed * Time.deltaTime;
		float mouseY = mouse.y * 20 * turnSpeed * Time.deltaTime;

		//player.Rotate(Vector3.up * mouseX);
		//to rotate only the camera on the Y axes
		rotation = isInverted ? rotation + mouseY : rotation - mouseY;
		rotationX += mouseX;
		transform.position = player.position + offset;
		rotation = Mathf.Clamp(rotation, -90f, 90f);
		rotationX = Mathf.Clamp(rotationX, -90f, 90f);

		transform.localRotation = Quaternion.Euler(rotation, rotationX, 0);
	}
}