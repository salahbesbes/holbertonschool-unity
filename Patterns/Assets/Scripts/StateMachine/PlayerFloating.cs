using UnityEngine;

public class PlayerFloating : AnyState
{
	public float Counter { get; private set; }
	private CharacterController charCon;
	public override void EnterState(PlayerStateManager playerContext)
	{
		//playerState.transform.Translate(new Vector3(0, 20, 0));
		charCon = playerContext.GetComponent<CharacterController>();
		charCon.Move(new Vector3(0, 20, 0) * 6 * Time.deltaTime);
		playerContext.GetComponent<Renderer>().material.color = Color.blue;

	}

	public override void Update(PlayerStateManager playerContext)
	{
		Counter += Time.deltaTime;


		// this is the condition to switch to an other state
		if (Counter % 60 >= 4f)
		{
			playerContext.transform.Translate(new Vector3(0, 1, 0));

			// this is the only way to change the current state
			playerContext.SwitchState(playerContext.PlayerGrow);
		}
		//execute share code 
		base.ExecuteInAnyState();
	}
	public override void OnCollisionEnter(PlayerStateManager playerContext)
	{
	}
}
