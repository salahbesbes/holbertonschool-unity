using UnityEngine;


public enum MainDirection
{
	left,
	right
}


public class ObsType2 : MonoBehaviour
{
	public float DistanceX;
	private Vector3 OriginalPos;
	private float distanceMoved;
	private float MaxdistanceForward;
	private float MaxdistanceBackward;
	private bool right = true;
	public MainDirection Movedirection;
	public float forwardSpeed = 5f;
	public float backwarddSpeed = 1f;
	private void Start()
	{
		OriginalPos = transform.position;


	}

	private void MoveLeft()
	{
		transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, Movedirection == MainDirection.left ? backwarddSpeed * Time.deltaTime : forwardSpeed * Time.deltaTime);
	}

	private void MoveRight()
	{
		transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, Movedirection == MainDirection.right ? backwarddSpeed * Time.deltaTime : forwardSpeed * Time.deltaTime);
	}

	private void Update()
	{
		MaxdistanceForward = OriginalPos.x + DistanceX;
		MaxdistanceBackward = OriginalPos.x - DistanceX;

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