using UnityEngine;

public class Turrent : MonoBehaviour
{
	[Header("General")]
	public float range = 15f;

	[Header("Use Lazer")]
	public bool UseLazer = false;

	public float slowPercent = 0.5f;
	public int damageOverTime = 30;
	public ParticleSystem lazerEffect;
	public LineRenderer lineRend;
	public Light lightPoint;
	private Enemy enemy;
	private Transform target;
	private string enemyTag = "Enemy";

	[Header("Unity Setup Fields")]
	public float turnSpeed = 10f;

	public Transform partToRotate;

	[Header("Attribute")]
	[Header("Use Bullet (default)")]
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
			enemy = target.GetComponent<Enemy>();
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
		if (target == null)
		{
			// we want to stop the lazer if we are using it
			if (UseLazer)
			{
				if (lineRend.enabled)
				{
					// disable the lineRendrer
					lineRend.enabled = false;
					// stop the particule effect
					lazerEffect.Stop();
					// stop the light point
					lightPoint.enabled = false;
				}
			}
			return;
		}
		LockOnTarger();

		if (UseLazer == true)
		{
			Lazer();
		}
		else
		{
			if (fireCountDown <= 0)
			{
				ShootToTarger();
				fireCountDown = 1f / fireRate;
			}
		}
		fireCountDown -= Time.deltaTime;
	}

	private void Lazer()
	{
		// do damage and slow fires each sec (not each frame) but the function executs each frame
		doDamage();
		slowEnemy();
		// enabling the lazer from firepoint to the target
		if (lineRend.enabled == false)
		{
			// enable the lazer
			lineRend.enabled = true;
			// start the particule effect
			lazerEffect.Play();
			// enable the lignt point
			lightPoint.enabled = true;
		}
		lineRend.SetPosition(0, firePoint.position);
		lineRend.SetPosition(1, target.position);

		// update the lazer effect position and rotation
		Vector3 dir = firePoint.position - target.position;
		lazerEffect.transform.position = target.position + dir.normalized;
		lazerEffect.transform.rotation = Quaternion.LookRotation(dir);
	}

	private void slowEnemy()
	{
		enemy.Slow(slowPercent);
	}

	private void doDamage()
	{
		enemy.takeDamage(damageOverTime * Time.deltaTime);
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

	private void LockOnTarger()
	{
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
	}
}