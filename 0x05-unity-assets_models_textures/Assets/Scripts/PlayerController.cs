using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController charCon;
	public float speed = 30f;
	//public float jumpVelocity = 0.5f;
	private void Start()
	{
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		float currentXPosition = Input.GetAxis("Horizontal");
		float currentZPosition = Input.GetAxis("Vertical");
		float jump = Input.GetAxis("Jump");

		Vector3 dir = new Vector3(currentXPosition, 0f, currentZPosition).normalized;

		Vector3 position = speed * Time.fixedDeltaTime * dir;



		charCon.Move(position);
		Debug.Log($"{jump}");

	}
}
