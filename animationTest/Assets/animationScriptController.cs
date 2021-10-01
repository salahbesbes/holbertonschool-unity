using UnityEngine;

public class animationScriptController : MonoBehaviour
{
	private Animator animator;
	private int isWalkingHash;
	private int isRunningHash;

	// Start is called before the first frame update
	private void Start()
	{
		animator = GetComponent<Animator>();
		isWalkingHash = Animator.StringToHash("isWalking");
		isRunningHash = Animator.StringToHash("isRunning");
	}

	// Update is called once per frame
	private void Update()
	{
		bool walkingButton = Input.GetKey("z"); // alway retrun true why pressing 'z' else by default return false every frame
		bool stopWalking = !walkingButton; // while not pressing 'z' stopwalking is true
		bool runButton = Input.GetKey(KeyCode.LeftShift);
		bool stopRunning = !runButton;

		bool isWalking = animator.GetBool(isWalkingHash); // status of the valiable in the animation
		bool isRunning = animator.GetBool(isRunningHash);

		if (walkingButton)
		{
			animator.SetBool(isWalkingHash, true);
		}
		if (isWalking)
		{
			// while walking we are pressing 'z' so stop "stopWalking" is false so if we
			// releaze the 'z' key stopWalking is true
			if (stopWalking)
			{
				animator.SetBool(isWalkingHash, false);
			}
		}
		if (isWalking && runButton)
		{
			animator.SetBool(isRunningHash, true);
		}
		if (isRunning)
		{
			if (stopWalking || stopRunning)
			{
				animator.SetBool(isRunningHash, false);
			}
		}
	}
}