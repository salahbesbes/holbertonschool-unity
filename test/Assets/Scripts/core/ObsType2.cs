using UnityEngine;

public class ObsType2 : MonoBehaviour
{
	public float DistanceZ;
	private Vector3 OriginalPos;
	private float distanceMoved;
	private float MaxdistanceForward;
	private float MaxdistanceBackward;
	private bool right = true;

	private void Start()
	{
		OriginalPos = transform.position;
	}

	private void MoveLeft()
	{
		transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left * 2, 10 * Time.deltaTime);
	}

	private void MoveRight()
	{
		transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right * 2, 5 * Time.deltaTime);
	}

	private void Update()
	{
		MaxdistanceForward = OriginalPos.x + DistanceZ;
		MaxdistanceBackward = OriginalPos.x - DistanceZ;

		distanceMoved = transform.position.x - OriginalPos.x;

		if (distanceMoved <= MaxdistanceForward && right)
		{
			MoveRight();
		}
		else
		{
			right = false;
		}
		if (distanceMoved >= MaxdistanceBackward && !right)
		{
			MoveLeft();
		}
		else
		{
			right = true;
		}
	}
}