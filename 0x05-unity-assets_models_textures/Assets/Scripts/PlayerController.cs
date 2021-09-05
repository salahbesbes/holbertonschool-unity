using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public CharacterController charCon;
	public float speed = 6f;
	public float maxJumpHeight = 20f;
	private bool isJumping = false;
	private bool isGrounded = true;
	// Update is called once per frame
	private float gravity = -9.8F;
	private Vector3 moveDirection = Vector3.zero;

	public Transform GameCamera;

	//public float jumpVelocity = 0.5f;
	private void Start()
	{
		charCon = GetComponent<CharacterController>();
	}


	private void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "DethEnd")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

	}

	void FixedUpdate()
	{
		isGrounded = charCon.isGrounded;
		if (isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = Mathf.Sqrt(maxJumpHeight * -3.0f * gravity);

		}
		// apply Gravity all frames
		moveDirection.y += gravity * Time.fixedDeltaTime * 4;


		charCon.Move(moveDirection * Time.fixedDeltaTime);

		/*
		isGrounded = charCon.isGrounded;
		if (isGrounded && moveDirection.y < 0)
		{
			moveDirection.y = 0f;
		}

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		charCon.Move(move * Time.deltaTime * speed);

		//if (move != Vector3.zero)
		//{
		//	gameObject.transform.forward = move;
		//}

		// Changes the height position of the player..
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			moveDirection.y += Mathf.Sqrt(maxJumpHeight * -3.0f * gravity);
		}

		moveDirection.y += gravity * Time.deltaTime;
		charCon.Move(moveDirection * Time.deltaTime);
		*/
	}


}
