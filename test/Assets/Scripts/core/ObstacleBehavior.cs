using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
	public Obstacle obs;

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			switch (obs.effects)
			{
				case Effects.Acceleration:
					Acceleration acce = new Acceleration();
					acce.OnHit(other.transform);
					break;

				case Effects.desceleration:
					Desceration desce = new Desceration();
					desce.OnHit(other.transform);
					break;

				case Effects.shaking:
					break;

				default:
					break;
			}
		}
	}
}