using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float startSpeed { get; private set; } = 10f;

	[HideInInspector]
	public float speed = 5f;

	public float health = 100;
	public GameObject DethEffect;
	public int Reward { get; private set; } = 50;

	private void Start()
	{
		speed = startSpeed;
	}

	public void takeDamage(float amoutDamage)
	{
		health -= amoutDamage;
		if (health <= 0) die();
	}

	private void GiveReward()
	{
		PlayerStats.Money += Reward;
	}

	private void die()
	{
		GiveReward();
		GameObject dethEff = Instantiate(DethEffect, transform.position, Quaternion.identity).gameObject;
		Destroy(dethEff, 5f);
		Destroy(gameObject);
	}

	public void Slow(float percentatge)
	{
		speed = startSpeed * (1 - percentatge);
	}
}