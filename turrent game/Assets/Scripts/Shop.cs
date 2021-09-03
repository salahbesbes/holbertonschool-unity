using UnityEngine;

public class Shop : MonoBehaviour
{
	BuildManager buildManager;
	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void purchaseStandardTurrent()
	{
		Debug.Log("standard turrent Selected");
		buildManager.TurrentToBuild = buildManager.defaultTurrent;
	}

	public void purchaseMissileLancherTurrent()
	{
		Debug.Log("MissileLancher turrent Selected");
		buildManager.TurrentToBuild = buildManager.anOtherTurrent;


	}
}
