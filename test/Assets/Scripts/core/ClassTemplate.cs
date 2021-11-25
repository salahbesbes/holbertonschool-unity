using UnityEngine;

public enum Effects
{
	Acceleration,
	desceleration,
	shaking
}

public enum PersonType
{
	cha3bi,
}

public class PrefabClass
{
	public GameObject Prefab { get; set; }
}

[System.Serializable]
public class Person : PrefabClass
{
	public string Name;
	public PersonType personType;

	public virtual void OnPickUp(Transform someone = null)
	{
		Debug.Log($" {Name} was picked up => need to ovverride this message");
	}

	public override string ToString()
	{
		return $"{GetType().Name} Class";
	}
}

[System.Serializable]
public class Obstacle : PrefabClass
{
	public string Name;

	public Effects effects;

	public virtual void OnHit(Transform someOne = null)
	{
		Debug.Log($" {Name} hit the player =>  need to ovverride this message");
	}

	public override string ToString()
	{
		return $"{GetType().Name} Class";
	}
}

public class Acceleration : Obstacle
{
	public float AccelerationValue = 10f;

	public override void OnHit(Transform someOne = null)
	{
		// todo: update the player stats
		PlayerStats playerStats = someOne.GetComponent<PlayerStats>();

		playerStats.speed += AccelerationValue;
	}
}

public class Desceration : Obstacle
{
	public float Acceleration = 10f;

	public override void OnHit(Transform someOne = null)
	{
		PlayerStats playerStats = someOne.GetComponent<PlayerStats>();

		playerStats.speed -= Acceleration;
	}
}

public class Cha3bi : Person
{
	public int PersonValue = 1;

	public override void OnPickUp(Transform someOne)
	{
		PlayerStats playerStats = someOne.GetComponent<PlayerStats>();

		playerStats.score += PersonValue;
	}
}