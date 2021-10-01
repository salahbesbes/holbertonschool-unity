using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 5f;
	public GameObject DethEffect;
	private Transform currentTarget;
	private int currentWayPointIndex = 0;
	public int health = 100;
	public int Reward { get; private set; } = 50;

	private void Start()
	{
		currentTarget = WayPoints.points[0];
	}

	// after we move the gameObject in the fixedupdate methode the camera detect new position in
	// the update methode
	private void FixedUpdate()
	{
		// get the V3 direction destination
		Vector3 dir = currentTarget.position - transform.position;
		// move the enemy to some new destination
		transform.Translate(speed * Time.fixedDeltaTime * dir.normalized, Space.World);
		// just before we get to the target we want calculate the new target
		if (Vector3.Distance(transform.position, currentTarget.position) <= 0.2f)
		{
			GetNextTarget();
		}
	}

	private void GetNextTarget()
	{
		// get the next target index
		currentWayPointIndex++;

		if (currentWayPointIndex >= WayPoints.points.Length)
		{
			EndPath();
			Destroy(gameObject);
			return;
		}
		// get the next target Transform
		currentTarget = WayPoints.points[currentWayPointIndex];
	}

	private void EndPath()
	{
		PlayerStats.Lives--;
	}

	public void takeDamage(int amoutDamage)
	{
		health -= amoutDamage;
		if (health <= 0) die();
	}

	private void die()
	{
		GiveReward();
		GameObject dethEff = Instantiate(DethEffect, transform.position, Quaternion.identity).gameObject;
		Destroy(dethEff, 5f);
		Destroy(gameObject);
	}

	private void GiveReward()
	{
		PlayerStats.Money += Reward;
	}
}