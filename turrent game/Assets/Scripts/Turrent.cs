using UnityEngine;

public class Turrent : MonoBehaviour
{
	private Transform target;
	private string enemyTag = "Enemy";

	[Header("Unity Setup Fields")]
	public float turnSpeed = 10f;

	public Transform partToRotate;

	[Header("Attribute")]
	public float range = 150f;

	public float fireRate = 1f;
	public float fireCountDown = 0f;
	public Transform bulletPrefab;
	public Transform firePoint;

	// Start is called before the first frame update
	private void Start()
	{
		// repeat "UpdateTarget" each 0.25 sec loop throw all ennemies and calculate
		// distance between turrent and ennemi and update shortestDistance and check if
		// target is in range and set the target
		InvokeRepeating("UpdateTarget", 0f, 0.1f);
	}

	private void UpdateTarget()
	{
		GameObject[] allEnemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in allEnemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
				nearestEnemy.GetComponent<Renderer>().material.color = Color.red;
			}
		}
		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		}
		else
		{
			if (nearestEnemy)
				nearestEnemy.GetComponent<Renderer>().material.color = Color.blue;

			target = null;
		}
	}

	// Update is called once per frame
	private void Update()
	{
		if (target == null) return;

		// handle rotation on axe Y
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		// smooth the rotation of the turrent
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,
						lookRotation,
						Time.deltaTime * turnSpeed
						)
						.eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (fireCountDown <= 0)
		{
			ShootToTarger();
			fireCountDown = 1f / fireRate;
		}
		fireCountDown -= Time.deltaTime;
	}

	private void ShootToTarger()
	{
		// we want to pass the target of the turrent to the bullet we are instanciating
		Transform bulletTransform = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		GameObject bulletGO = bulletTransform.gameObject;

		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
		{
			bullet.Seek(target);
		}
	}

	// find a target : within a range && nearest one then rotate to aim at that target
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}