using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform target;
	public float speed = 15f;

	public GameObject impactEffect;
	public float explosionRadius;

	// setting the target of the bullet (which is sent by the turrent)
	public void Seek(Transform _target)
	{
		target = _target;
	}

	private void Update()
	{
		// if the target still alive we want to move toward it until we reach it (hit him)
		if (target)
		{
			Vector3 dir = target.position - transform.position;
			float distanceThisFrame = speed * Time.deltaTime;

			if (dir.magnitude <= distanceThisFrame)
			{
				HitTarget();
				return;
			}
			// move the bullet to the target
			transform.Translate(dir.normalized * distanceThisFrame, Space.World);
			// rotate the bullet towwarrd the target
			transform.LookAt(target);
		}
		// in the midle way of the target if it does no more exist we want to destroy the bulltet
		else
		{
			Destroy(gameObject);
		}
	}

	private void HitTarget()
	{


		if (explosionRadius > 0f)
		{
			// damage all Enemies in a range
			Explosion();
		}
		else
		{
			// damage single enemy
			DamageEnemy(target);
		}
		// always destroy the bullet
		Destroy(gameObject);
	}

	private void Explosion()
	{
		// get all collider in Sphere
		Collider[] objectsHit = Physics.OverlapSphere(transform.position, explosionRadius);

		foreach (Collider obj in objectsHit)
		{
			// create an effect that last for 2s
			GameObject Impacteffect = Instantiate(impactEffect, transform.position, transform.rotation).gameObject;
			Destroy(Impacteffect, 5f);
			// damage only tagged obj == Enemy
			if (obj.tag == "Enemy")
			{
				DamageEnemy(obj.transform);
			}
		}
	}

	private void DamageEnemy(Transform enemy)
	{
		Destroy(enemy.gameObject);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}