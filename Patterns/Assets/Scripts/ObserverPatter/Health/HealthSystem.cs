using System;
using UnityEngine;

// the instance of this Class lives in the PlayerStats Class
public class HealthSystem
{
	// this is Sybject that have Observer(s) subscribed to it, each time the delegate variable
	// is Invoked() the Event Notify all Observers to ececute some callBackFunctions
	public static event Action HealthEvent = delegate { };

	private float health;

	private float maxHealth;

	public HealthSystem(float maxHealth)
	{
		this.maxHealth = maxHealth;
		health = maxHealth;
	}

	public float GetHealth()
	{
		return health;
	}

	public float GetHealthPercent()
	{
		return health / maxHealth;
	}

	public void Damage(float amount)
	{
		health -= amount;
		health = Mathf.Clamp(health, 0, int.MaxValue);
		HealthEvent.Invoke();
	}

	public void Heal(float amount)
	{
		health += amount;
		health = Mathf.Clamp(health, 0, maxHealth);
		HealthEvent.Invoke();
	}
}