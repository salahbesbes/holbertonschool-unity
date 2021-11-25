using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
	public float DistanceZ;
	private Vector3 OriginalPos;
	private float distanceMoved;
	private float MaxdistanceForward;
	private float MaxdistanceBackward;
	private bool forward;
	private bool moveBack;

	private void Start()
	{
		OriginalPos = transform.position;
	}

	private void MoveForward()
	{
		transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward * 2, 30 * Time.deltaTime);
	}

	private void MoveBackaArd()
	{
		transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.back * 2, 5 * Time.deltaTime);
	}

	private void Update()
	{
		MaxdistanceForward = OriginalPos.z + DistanceZ;
		MaxdistanceBackward = OriginalPos.z - DistanceZ;

		distanceMoved = transform.position.z - OriginalPos.z;
		if (distanceMoved <= MaxdistanceForward && forward)
		{
			MoveForward();
		}
		else
		{
			forward = false;
		}
		if (distanceMoved >= MaxdistanceBackward && !forward)
		{
			MoveBackaArd();
		}
		else
		{
			forward = true;
		}
	}
}