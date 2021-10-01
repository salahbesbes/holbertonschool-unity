using UnityEngine;

public class PlayerGrowing : AnyState
{
	Vector3 growRate = new Vector3(0.3f, 0.3f, 0.3f);
	public override void EnterState(PlayerStateManager playerContext)
	{
		playerContext.GetComponent<Renderer>().material.color = Color.cyan;
	}

	public override void Update(PlayerStateManager playerContext)
	{
		if (playerContext.transform.localScale.x < 4)
		{
			playerContext.transform.localScale += growRate * Time.deltaTime;
		}
		else
		{
			playerContext.transform.localScale = new Vector3(1, 1, 1);
		}

		//execute share code 
		base.ExecuteInAnyState();

	}
	public override void OnCollisionEnter(PlayerStateManager playerContext)
	{
	}

}
