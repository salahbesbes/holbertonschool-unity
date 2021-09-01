using UnityEngine;

public class BuildManager : MonoBehaviour
{

	public static BuildManager instance;


	private void Awake()
	{
		if (instance == null) instance = this;
		else
		{
			Debug.Log("more than build manager in seane");
		}
	}


	public GameObject defaultTurrent;


	private void Start()
	{
		_turrentToBuild = defaultTurrent;

	}
	private GameObject _turrentToBuild;
	public GameObject TurrentToBuild
	{
		get => _turrentToBuild;
	}
}