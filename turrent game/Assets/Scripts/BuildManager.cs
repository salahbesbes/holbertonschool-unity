using UnityEngine;

public class BuildManager : MonoBehaviour
{


	// this is a singletan pattern ( creates a single instace lives
	// in the hole program accessible by any other GameObject
	// that share coherent data 
	public static BuildManager instance;
	private void Awake()
	{
		if (instance == null) instance = this;
		else
		{
			Debug.Log("more than build manager in seane");
		}
	}

	// all type of item to build exist in this instance 
	// each will type have a privet field that have setter and getter
	public GameObject defaultTurrent;
	public GameObject anOtherTurrent;



	private GameObject _turrentToBuild;
	public GameObject TurrentToBuild
	{
		get => _turrentToBuild;
		set => _turrentToBuild = value;

	}
}