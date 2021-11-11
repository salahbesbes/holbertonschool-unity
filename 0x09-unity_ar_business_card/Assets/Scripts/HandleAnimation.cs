using UnityEngine;

public class HandleAnimation : MonoBehaviour
{
	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void OnFoundSomeTarget()
	{
		animator.Play("cubeAnim");
	}
}