using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
	// Current state of the player, this script is attached to the object of interest
	// the player object is accessible in this class and other children
	public PlayerBaseState State { get; private set; }


	//  initialise 4 stat of the Player
	// 4 instatnce that lives in this class
	public PlayerFloating PlayerFloat = new PlayerFloating();
	public PlayerRunning PlayerRun = new PlayerRunning();
	public PlayerGrowing PlayerGrow = new PlayerGrowing();
	public PlayerGrounded PlayerGround = new PlayerGrounded();


	void Start()
	{
		// when start we set  PlayerGround as default init state
		State = PlayerGround;
		State.EnterState(this);
	}
	void Update()
	{
		// for any state the player is in, we execute the update methode of that State
		// change of the state is instant since this update executs every frame
		State.Update(this);
	}

	public void SwitchState(PlayerBaseState newState)
	{
		// change the current state and execute the start methode of that new State
		// this is the only way to change the state
		State = newState;
		State.EnterState(this);
	}
}
