using System;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{



	public static event Action<int> Heal = delegate { };
	public static event Action ChangeState = delegate { };
	public static event Action UpdateAchievement = delegate { };

	private int _health = 20;
	public int Health
	{
		get => _health;

		set
		{
			if (value >= 20)
			{
				value = 20;
			}

			_health = value;

		}
	}




	public void HealPlayer(int amount)
	{
		Health += amount;
		Heal.Invoke(amount);
	}




}
