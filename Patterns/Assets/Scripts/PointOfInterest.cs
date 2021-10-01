using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : Subject
{

	private List<Observable> _observables = new List<Observable>();


	private void OnTriggerEnter(Collider other)
	{
		Notify(other);
	}

	public override void Notify(Collider collider)
	{
		Debug.Log($" length of observables {_observables.Count}");

		foreach (Observable ob in _observables)
		{
			ob.UpdateObservable(collider);
		}
	}

	public override void Register(Observable observable)
	{
		_observables.Add(observable);
	}

}


