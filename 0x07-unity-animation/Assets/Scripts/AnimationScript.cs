using UnityEngine;

public class AnimationScript : MonoBehaviour
{
	private Animator animator;
	private int isWalkingHash;
	private int isRunningHash;

	private void Start()
	{
		animator = GetComponent<Animator>();
		isWalkingHash = Animator.StringToHash("isWalking");
		isRunningHash = Animator.StringToHash("isRunning");
	}

	private void Update()
	{
		bool walkingButton = Mathf.Abs(Input.GetAxis("Vertical")) > 0;

		Debug.Log($"walking {walkingButton}");
		bool stopWalking = !walkingButton;
		bool isWalking = animator.GetBool(isWalkingHash);
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
	}
}