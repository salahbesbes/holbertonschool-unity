using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 10f;

	private Transform currentTarget;
	private int currentWayPointIndex = 0;

	private void Start()
	{
		currentTarget = WayPoints.points[0];
	}

	private void Update()
	{
		// get the V3 direction destination
		Vector3 dir = currentTarget.position - transform.position;
		// move the enemy to some new destination
		transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);
		// just before we get to the target we want calculate the new target
		if (Vector3.Distance(transform.position, currentTarget.position) <= 0.1f)
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
			Destroy(gameObject);
			return;
		}
		// get the next target Transform
		currentTarget = WayPoints.points[currentWayPointIndex];
	}
}