using UnityEngine;

public abstract class ObserverStateAbstract : MonoBehaviour
{
	protected PlayerStateManager StateSubject { get; set; }

	public virtual void Subsribe(PlayerStateManager Subject)
	{
		StateSubject = Subject;
		PlayerStateManager.StateEvent += OnStateChange;
	}

	public abstract void OnStateChange(PlayerBaseState newState);
}