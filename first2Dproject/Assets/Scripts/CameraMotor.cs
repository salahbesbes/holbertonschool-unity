using UnityEngine;

public class CameraMotor : MonoBehaviour
{
	public Transform LookAt;
	public float RightEdge = 0.3f;
	private float LeftEdge;
	public float TopEdge = 0.15f;
	private float ButtomEdge;

	private void Start()
	{
		LeftEdge = -RightEdge;
		ButtomEdge = -TopEdge;
	}

	private void LateUpdate()
	{
		Vector3 delta = Vector3.zero;

		float deltaX = LookAt.position.x - transform.position.x;

		// create an invisible box around the lookAt position if the player pass the edges
		// of the box the camera update its position
		if (deltaX > RightEdge || deltaX < LeftEdge)
		{
			if (transform.position.x < LookAt.position.x)
			{
				delta.x = deltaX + LeftEdge;
			}
			else
			{
				delta.x = deltaX + RightEdge;
			}
		}

		float deltaY = LookAt.position.y - transform.position.y;
		if (deltaY > TopEdge || deltaY < ButtomEdge)
		{
			if (transform.position.y < LookAt.position.y)
			{
				delta.y = deltaY + ButtomEdge;
			}
			else
			{
				delta.y = deltaY + TopEdge;
			}
		}

		// each frame the camera update its position but it wont move unless delta is filled
		// with some values because each frame we reset it to Vector3.zero

		transform.Translate(delta);
	}
}