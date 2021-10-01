public abstract class PlayerBaseState
{
	public abstract void EnterState(PlayerStateManager playerContext);

	public abstract void Update(PlayerStateManager playerContext);

	public abstract void OnCollisionEnter(PlayerStateManager playerContext);
}

// this class inhirit from PlayerBaseState Class the role of this class is to share (execute) code
// that all state execute it
public abstract class AnyState : PlayerBaseState
{
	// if we want to execute code in all states in the update methode
	public virtual void ExecuteInAnyState()
	{
		//UnityEngine.Debug.Log($" always execute in any state ");
	}
}