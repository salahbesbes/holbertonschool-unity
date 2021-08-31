using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform target;
	public float speed = 15f;

	public GameObject impactEffect;

	// setting the target of the bullet (which is sent by the turrent)
	public void Seek(Transform _target)
	{
		target = _target;
	}

	private void Update()
	{
		// the target sent by the turrent could be null so in this case we dont want to
		// destroy the bullet

		//if (target == null)
		//{
		//	Destroy(gameObject);
		//	return;
		//}
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
		}
		Debug.Log($"{target}");
	}

	private void HitTarget()
	{
		GameObject Impacteffect = Instantiate(impactEffect, transform.position, transform.rotation).gameObject;
		Destroy(Impacteffect, 2f);
		Destroy(gameObject);
		Destroy(target.gameObject);
	}
}