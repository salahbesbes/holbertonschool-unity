using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController charCon;
	public Canvas pauseCanvas;

	public float speed = 6f;
	public float maxJumpHeight = 10f;
	private bool isGrounded = true;
	private Vector3 startPosition;

	// Update is called once per frame
	private float gravity = -9.8f * 2;

	private Vector3 gravityVelocity = Vector3.zero;

	//public float jumpVelocity = 0.5f;

	private void Start()
	{
		// make sure the time scale when the player is rendred is 1
		Time.timeScale = 1;
		charCon = GetComponent<CharacterController>();
		startPosition = transform.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "DethEnd")
		{
			// note this line will not work !! why
			//transform.position = new Vector3(0.0f, 10.0f, 0.0f);
		}
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			// get the pause menu
			PauseMenu pauseMenu = pauseCanvas.GetComponent<PauseMenu>();

			// check if he pause canvas is active and enabled if not
			if (pauseCanvas.isActiveAndEnabled == false)
			{
				// after we pause the game the update methode of the player will not
				// run any more so to resume the game the only way is to click on a
				// button resume in the canvas not to press the escape buuton again
				pauseMenu.Pause();
			}
		}

		isGrounded = charCon.isGrounded;

		if (isGrounded && gravityVelocity.y < 0)
		{
			gravityVelocity.y = -2f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		// handle movement
		Vector3 direction = transform.forward * z;
		Vector3 dirRotation = Vector3.up * x * 500;
		transform.Rotate(dirRotation * Time.deltaTime);
		charCon.Move(direction * speed * Time.deltaTime);

		//handle jump
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			gravityVelocity.y = Mathf.Sqrt(maxJumpHeight * -3.0f * gravity);
		}
		//handle gravity
		gravityVelocity.y += gravity * Time.deltaTime;
		charCon.Move(gravityVelocity * Time.deltaTime);

		// note why this code work properly but does not work in OnTriggerEnter method
		if (transform.position.y < -30.0f)
		{
			transform.position = startPosition + new Vector3(0f, 10f, 0f);
		}
	}
}