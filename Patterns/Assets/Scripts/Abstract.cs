using UnityEngine;




public abstract class Observable : MonoBehaviour
{
	public virtual void UpdateObservable(Collider collider)
	{

	}
}



public abstract class Subject : MonoBehaviour
{

	public virtual void Register(Observable observable)
	{
	}
	public virtual void Notify(Collider observableName)
	{

	}
}
