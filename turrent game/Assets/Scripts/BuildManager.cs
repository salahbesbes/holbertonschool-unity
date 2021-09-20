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


	public GameObject buildEffect;

	public bool CanBuild { get { return _turrentToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= TurrentToBuild.cost; } }

	private TurrentBluePrint _turrentToBuild;
	public TurrentBluePrint TurrentToBuild
	{
		get => _turrentToBuild;
		set => _turrentToBuild = value;

	}


	public void BuildTurrentOn(Node node)
	{
		Debug.Log($"{PlayerStats.Money } {TurrentToBuild.cost}");
		// check if for money
		if (HasMoney == false)
		{
			Debug.Log($"not enough money to build");
			return;
		}

		PlayerStats.Money -= TurrentToBuild.cost;
		Debug.Log($"Money left after purchase {PlayerStats.Money}");

		// build turrent
		GameObject turrent = Instantiate(TurrentToBuild.prefab, node.transform.position + node.offset, Quaternion.identity).gameObject;
		node.turrent = turrent;
		// create Build Effect
		GameObject effect = Instantiate(buildEffect, node.transform.position, node.transform.rotation).gameObject;
		Destroy(effect, 5f);

	}


}