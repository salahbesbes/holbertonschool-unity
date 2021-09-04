using UnityEngine;

public class Shop : MonoBehaviour
{
	BuildManager buildManager;
	void Awake()
	{
		buildManager = BuildManager.instance;
	}


	public TurrentBluePrint standardTurrent;
	public TurrentBluePrint missileLuncher;




	public void selectStandardTurrent()
	{
		Debug.Log("standard turrent Selected");
		buildManager.TurrentToBuild = buildManager.defaultTurrent;
	}

	public void selecteMissileLancherTurrent()
	{
		Debug.Log("MissileLancher turrent Selected");
		buildManager.TurrentToBuild = buildManager.anOtherTurrent;


	}
}
