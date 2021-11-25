using UnityEngine;

public class ObstacleType1 : MonoBehaviour
{
	public Transform partToRotate;

	private void Update()
	{
		partToRotate.RotateAround(partToRotate.position, Vector3.up, Time.deltaTime * 200);
	}

	//private void LockOnTarger()
	//{
	//	// handle rotation on axe Y
	//	Vector3 dir = target.position - transform.position;
	//	Quaternion lookRotation = Quaternion.LookRotation(dir);
	//	// smooth the rotation of the turrent
	//	Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,
	//					lookRotation,
	//					Time.deltaTime * turnSpeed
	//					)
	//					.eulerAngles;
	//	partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	//}
}