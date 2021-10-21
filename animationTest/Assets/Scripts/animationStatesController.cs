using UnityEngine;

public class animationStatesController : MonoBehaviour
{
	private Animator animator;
	private int velocityHash;
	public float acceleration = 0.3f;
	private float velocity;
	public float decelaration = 0.5f;

	// Start is called before the first frame update
	private void Start()
	{
		animator = GetComponent<Animator>();
		velocityHash = Animator.StringToHash("velocity");
	}

	// Update is called once per frame
	private void Update()
	{
		bool walkingButton = Input.GetKey("z");
		bool stopWalking = !walkingButton;
		bool runButton = Input.GetKey(KeyCode.LeftShift);
		bool stopRunning = !runButton;

		if (walkingButton && velocity < 1)
		{
			velocity += Mathf.Abs(Time.deltaTime * acceleration);
		}
		if (stopWalking && velocity >= 0)
		{
			velocity -= Mathf.Abs(Time.deltaTime * decelaration);
		}

		animator.SetFloat(velocityHash, velocity);
	}
}