using UnityEngine;

// this abstract class inhirit from Monobehaviour
public abstract class ObserverAbstraction : MonoBehaviour
{
	// every observer (UI...) need to subscribe the the Subject (HealSystem) the Subject is
	// protected because we want to use it only in the Observes Classes and no need to attach
	protected HealthSystem healthSystem { get; set; }

	// every subscriber need a ref to the Subject and a callBack function to execute since this
	// code is the same for every Observer we can use the Virtual keyWord to implement it
	public virtual void Subsribe(HealthSystem Subject)
	{
		// save the HealthSystem instance into this Observer
		healthSystem = Subject;
		// subscribe the Observer to the Subject ( this is execute first thing in the
		// PlayerStats )
		HealthSystem.HealthEvent += OnHealthChange;
	}

	// since each Observer will have a different logic implementation we use the keyWord abstract
	public abstract void OnHealthChange();
}