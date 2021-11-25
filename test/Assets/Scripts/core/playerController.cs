using UnityEngine;

public class playerController : MonoBehaviour
{
	private CharacterController controller;
	public float speed = 5f;

	public float distance;

	private Vector2 startPosition;
	private bool fingerDown;

	//public float movmentSpeed = 2f;
	public int pixelsDistToDetect = 7;

	// Start is called before the first frame update
	private void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
	}

	// Update is called once per frame
	private void Update()
	{
		// Testing for PC
		if (fingerDown == false && Input.GetMouseButton(0))
		{
			startPosition = Input.mousePosition;
			fingerDown = true;
		}

		if (fingerDown)
		{
			if (Input.mousePosition.x >= startPosition.x + pixelsDistToDetect)
			{
				fingerDown = false;
				controller.Move(Vector3.right);
				//Vector3.Lerp(transform.position, Vector3.right, Time.deltaTime);
			}

			if (Input.mousePosition.x <= startPosition.x - pixelsDistToDetect)
			{
				fingerDown = false;
				controller.Move(Vector3.left);
			}
		}

		controller.Move((Vector3.forward * speed) * Time.deltaTime);
	}
}