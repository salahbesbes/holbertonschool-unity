using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public static float Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 12;
	public static int Rounds;

	private void Start()
	{
		Lives = startLives;
		Money = startMoney;
		Rounds = 0;
	}
}