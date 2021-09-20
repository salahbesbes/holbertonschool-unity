using UnityEngine;

public class Shop : MonoBehaviour
{
	private BuildManager buildManager;


	public TurrentBluePrint standardTurrent;
	public TurrentBluePrint missileLuncher;



	void Awake()
	{
		buildManager = BuildManager.instance;
	}






	public void SelectStandardTurrent()
	{
		Debug.Log("standard turrent Selected");
		buildManager.TurrentToBuild = standardTurrent;
	}

	public void SelecteMissileLancherTurrent()
	{
		Debug.Log("MissileLancher turrent Selected");
		buildManager.TurrentToBuild = missileLuncher;


	}
}
