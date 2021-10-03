using UnityEngine;

public class AnimationScript : MonoBehaviour
{
	private Animator animator;
	private int isWalkingHash;
	private int isJumpingHash;
	private CharacterController charCon;
	private void Start()
	{
		animator = GetComponent<Animator>();
		isWalkingHash = Animator.StringToHash("isWalking");
		isJumpingHash = Animator.StringToHash("isJumping");
		charCon = GetComponent<CharacterController>();

	}

	private void Update()
	{
		bool walkingButton = Mathf.Abs(Input.GetAxis("Vertical")) > 0;
		bool jumpingButton = Input.GetKey(KeyCode.Space);
		bool isGrounded = charCon.isGrounded;
		Debug.Log($"walking {walkingButton}");
		bool stopWalking = !walkingButton;
		bool isWalking = animator.GetBool(isWalkingHash);
		bool isJumping = animator.GetBool(isJumpingHash);

		if (walkingButton && !isJumping)
		{
			animator.SetBool(isWalkingHash, true);
			animator.SetBool(isJumpingHash, false);
		}
		if (isWalking)
		{
			// while walking we are pressing 'z' so stop "stopWalking" is false so if we
			// releaze the 'z' key stopWalking is true
			if (stopWalking)
			{
				animator.SetBool(isWalkingHash, false);
				animator.SetBool(isJumpingHash, false);
			}


			if (jumpingButton)
			{
				animator.SetBool(isWalkingHash, false);
				animator.SetBool(isJumpingHash, true);
			}
		}

		if (isJumping)
		{
			if (isGrounded)
			{
				if (walkingButton)
				{
					animator.SetBool(isWalkingHash, true);
					animator.SetBool(isJumpingHash, false);
				}
				else
				{

					animator.SetBool(isWalkingHash, false);
					animator.SetBool(isJumpingHash, false);

				}
			}

		}


		if (isWalking)
		{
			animator.SetBool(isJumpingHash, false);

		}


		if (jumpingButton)
		{
			animator.SetBool(isJumpingHash, true);
		}
	}
}