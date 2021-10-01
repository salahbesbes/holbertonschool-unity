using UnityEngine;

public class PlayerRunning : AnyState
{
	PlayerController PC;
	Color InitColor;

	public float Counter { get; private set; }

	public override void EnterState(PlayerStateManager playerContext)
	{
		Debug.Log($" execute from the running state");
		PC = playerContext.GetComponent<PlayerController>();
		PC.speed = 20;
		InitColor = playerContext.GetComponent<Renderer>().material.color;
		playerContext.GetComponent<Renderer>().material.color = Color.green;


	}

	public override void Update(PlayerStateManager playerContext)
	{



		Counter += Time.deltaTime;

		// this is the condition to switch to an other state
		if (Counter % 60 >= 4f)
		{

			// this is the only way to change the current state
			playerContext.SwitchState(playerContext.PlayerFloat);
		}
		// this code execute in any State
		base.ExecuteInAnyState();
	}

	public override void OnCollisionEnter(PlayerStateManager playerContext)
	{
	}

}
