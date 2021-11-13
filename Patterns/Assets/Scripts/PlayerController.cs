using gameEventNameSpace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private VoidEvent onCharacterJump;

	public CharacterController charCon;

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
		//GetComponent<PlayerStatus>().HealPlayer(5);
	}

	private void Update()
	{
		isGrounded = charCon.isGrounded;

		if (isGrounded && gravityVelocity.y < 0)
		{
			gravityVelocity.y = -2f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		// handle movement
		Vector3 direction = transform.right * x + transform.forward * z;
		charCon.Move(direction * speed * Time.deltaTime);
		Debug.Log($"{Input.GetButtonDown("Jump")}  grounded {isGrounded}");
		//handle jump
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			onCharacterJump.Raise();
			gravityVelocity.y = Mathf.Sqrt(maxJumpHeight * -3.0f * gravity);
		}
		//handle gravity
		gravityVelocity.y += gravity * Time.deltaTime;
		charCon.Move(gravityVelocity * Time.deltaTime);
		//// note why this code work properly but does not work in OnTriggerEnter method
		//if (transform.position.y < -30.0f)
		//{
		//	transform.position = startPosition + new Vector3(0f, 10f, 0f);
		//}
	}

	private void OnCollisionEnter(Collision collision)
	{
	}
}