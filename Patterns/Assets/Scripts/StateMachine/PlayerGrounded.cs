using UnityEngine;

public class PlayerGrounded : AnyState
{
	private Color initialColor;
	private float Counter;

	public override void EnterState(PlayerStateManager playerContext)
	{
		Debug.Log($"hello from grounded State");
		initialColor = playerContext.GetComponent<Renderer>().material.color;
	}

	public override void Update(PlayerStateManager playerContext)
	{
		playerContext.GetComponent<Renderer>().material.color = Color.black;
		playerContext.GetComponent<PlayerController>().enabled = true;

		Counter += Time.deltaTime;

		//this is the condition to switch to an other state
		if (Counter % 60 >= 4f)
		{
			// this is the only way to change the current state
			playerContext.SwitchState(playerContext.PlayerRun);
		}

		//execute share code
		base.ExecuteInAnyState();
	}

	public override void OnCollisionEnter(PlayerStateManager playerContext)
	{
	}
}