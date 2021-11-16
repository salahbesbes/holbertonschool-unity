using UnityEngine;

public class playerController : MonoBehaviour
{
	private CharacterController controller;
	public float speed = 5f;

	public float distance;

	// Start is called before the first frame update
	private void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
	}

	// Update is called once per frame
	private void Update()
	{
		controller.Move((Vector3.forward * speed) * Time.deltaTime);
	}
}