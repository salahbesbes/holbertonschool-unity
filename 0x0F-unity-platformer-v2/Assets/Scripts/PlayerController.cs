using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public CharacterController charCon;
	public Canvas pauseCanvas;
	public Animator animator;

	public float speed = 6f;
	public float maxJumpHeight = 10f;
	private bool isGrounded = true;
	private Vector3 startPosition;

	// Update is called once per frame
	private float gravity = -9.8f * 2;

	private Vector3 gravityVelocity = Vector3.zero;
	private PlayerInput input;
	//public float jumpVelocity = 0.5f;

	private void Awake()
	{
		input = GetComponent<PlayerInput>();
	}

	private void Start()
	{
		// make sure the time scale when the player is rendred is 1
		Time.timeScale = 1;
		charCon = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
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

	public void gamePause()
	{
		PauseMenu pauseMenu = pauseCanvas.GetComponent<PauseMenu>();
		// active and enabled if not
		if (pauseCanvas.isActiveAndEnabled == false)
		{ // after we pause the game the update methode of the player will not //
		  // run any more so to resume the game the only way is to click on a // button
		  // resume in the canvas not to press the escape buuton again
			pauseMenu.Pause();
		}
	}

	private void Update()
	{
		if (input.actions["escape"].triggered)
		{
			gamePause();
		}

		isGrounded = charCon.isGrounded;

		if (isGrounded && gravityVelocity.y < 0) { gravityVelocity.y = -2f; }

		//float x = Input.GetAxis("Horizontal");
		//float z = Input.GetAxis("Vertical");

		// handle movement

		Vector2 movementInput = input.actions["move"].ReadValue<Vector2>();
		Vector3 direction = transform.forward * movementInput.y;
		Vector3 dirRotation = Vector3.up * movementInput.x * 500; transform.Rotate(dirRotation * Time.deltaTime);

		charCon.Move(direction * speed * Time.deltaTime);

		if (input.actions["jump"].triggered && isGrounded)
		{
			gravityVelocity.y = Mathf.Sqrt(maxJumpHeight * -3.0f * gravity);
		}

		gravityVelocity.y += gravity * Time.deltaTime; charCon.Move(gravityVelocity * Time.deltaTime);

		if (transform.position.y < -30.0f)
		{
			transform.position = startPosition + new Vector3(0f, 10f, 0f);
		}
	}
}