using UnityEngine;

public class RunningState : StateMachineBehaviour
{

	AudioSource runningSound;
	RaycastHit hit;
	//OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (Physics.Raycast(animator.transform.position, Vector3.down, out hit, 100.0f))
		{
			Renderer renderer = hit.transform?.gameObject?.GetComponent<Renderer>();
			if (renderer)
			{
				if (renderer.material.name.Contains("Wood"))
				{
					AudioManager manager = FindObjectOfType<AudioManager>();
					//manager.Play("WoodSound");
					//Debug.Log($"{"WoodSound"}");
				}
				else if (renderer.material.name.Contains("Stone"))
				{
					AudioManager manager = FindObjectOfType<AudioManager>();

					//manager.Play("StoneSound");
					//Debug.Log($"StoneSound");
				}

			}
		}
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{


	}

	//OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		AudioManager manager = FindObjectOfType<AudioManager>();
		//manager.Stop("WoodSound");
		//manager.Stop("StoneSound");
	}


	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

	}

}
