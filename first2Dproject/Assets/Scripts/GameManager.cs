using System.Collections.Generic;
using UnityEngine;

public class GameManager : Collectable
{


	public static GameManager Instance;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}


	// Ressources
	public List<Sprite> PlayerSprites;
	public List<Sprite> WeponsSprites;
	public List<int> WeponPrices;
	public List<int> XpTable;


	// Reference
	public Player Player;


	// Logics
	public int Pesos;
	public int Experience;

}


