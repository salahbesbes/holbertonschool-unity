using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 5f;

	private Transform currentTarget;
	private int currentWayPointIndex = 0;

	private void Start()
	{
		currentTarget = WayPoints.points[0];
	}
	// after we move the gameObject in the fixedupdate methode the camera detect
	// new position in the update methode 
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
			Destroy(gameObject);
			return;
		}
		// get the next target Transform
		currentTarget = WayPoints.points[currentWayPointIndex];
	}
}