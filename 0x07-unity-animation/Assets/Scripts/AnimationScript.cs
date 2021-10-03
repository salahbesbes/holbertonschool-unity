using UnityEngine;

public class AnimationScript : MonoBehaviour
{
	private Animator animator;
	private int isWalkingHash, isJumpingHash, isFallingHash, beforeImpactHash;
	private CharacterController charCon;
	private float lastY;

	private void Start()
	{
		animator = GetComponent<Animator>();
		isWalkingHash = Animator.StringToHash("isWalking");
		isJumpingHash = Animator.StringToHash("isJumping");
		isFallingHash = Animator.StringToHash("isFalling");
		beforeImpactHash = Animator.StringToHash("beforeImpact");
		charCon = GetComponent<CharacterController>();
		lastY = transform.position.y;
	}

	private void Update()
	{
		bool walkingButton = Mathf.Abs(Input.GetAxis("Vertical")) > 0;
		bool jumpingButton = Input.GetKey(KeyCode.Space);
		bool isGrounded = charCon.isGrounded;
		bool isNotGrounded = !isGrounded;
		bool stopWalking = !walkingButton;
		bool isWalking = animator.GetBool(isWalkingHash);
		bool isJumping = animator.GetBool(isJumpingHash);
		bool isfalling = animator.GetBool(isFallingHash);
		bool isFlat = animator.GetBool(beforeImpactHash);
		float distancePerSecondSinceLastFrame = (transform.position.y - lastY) * Time.deltaTime;
		lastY = transform.position.y;  //set for next frame

		if (walkingButton && !isJumping)
		{
			animator.SetBool(isWalkingHash, true);
			animator.SetBool(isJumpingHash, false);
		}


		if (jumpingButton)
		{
			animator.SetBool(isWalkingHash, false);
			animator.SetBool(isJumpingHash, true);
		}
		if (isWalking)
		{

			if (distancePerSecondSinceLastFrame < 0 && transform.position.y < 0)
			{
				animator.SetBool(isFallingHash, true);
			}

			animator.SetBool(isJumpingHash, false);

			if (stopWalking)
			{
				animator.SetBool(isWalkingHash, false);
				animator.SetBool(isJumpingHash, false);
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

			if (distancePerSecondSinceLastFrame < 0 && transform.position.y < 0)
			{
				animator.SetBool(isFallingHash, true);
			}

		}

		if (isGrounded)
		{
			animator.SetBool(isFallingHash, false);
		}

	}
}
